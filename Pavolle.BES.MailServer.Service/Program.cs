using log4net;
using Pavolle.BES.MailServer.Business.Manager;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.WebFilter;
using Pavolle.Core.Manager;

internal class Program
{
    private static void Main(string[] args)
    {
        var log4netRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        log4net.Config.XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));
        var builder = WebApplication.CreateBuilder(args);

        ILog _log = LogManager.GetLogger(typeof(Program));
        WebAppInfoManager.Instance.Initialize("Mail Server", "1.0.0", "MAILS-PLLE-112328-TA", new DateTime(2023, 12, 29));

        _log.Info("  ");
        _log.Info("********************************************");
        _log.Info("Pavolle - " + WebAppInfoManager.Instance.GetAppCode() + " ");
        _log.Info("Version Release Date => " + WebAppInfoManager.Instance.GetReleaseDate());
        _log.Info("App ID => " + WebAppInfoManager.Instance.GetId());
        _log.Info("********************************************");


        var settings = builder.Configuration.GetSection("Settings").Get<Settings>();
        _log.Info("Setting Server URL is " + settings.SettingServerUrl);


        SettingServiceManager.Instance.Initialize(settings.SettingServerUrl, WebAppInfoManager.Instance.GetAppCode(), WebAppInfoManager.Instance.GetId());
        var settingServerStatus = SettingServiceManager.Instance.GetServerStatus();
        if (settingServerStatus == null || !settingServerStatus.ServerStatus)
        {
            _log.Error("Setting server is not active! Application closing!");
            return;
        }
        else
        {
            MailServerStatusManager.Instance.SetSettingServerConnectionStatus(true);
        }

        var dbStatus = MailServerDbManager.Instance.InitializeDb(SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection));
        MailServerStatusManager.Instance.SetDbStatus(dbStatus);

        TranslateServerHelperManager.Instance.Initialize(SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl), WebAppInfoManager.Instance.GetAppCode(), WebAppInfoManager.Instance.GetId());
        TranslateServiceManager.Instance.Initialize();

        bool rabbitMQStatus = RabbitMQManager.Instance.Initilize(
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQUsername),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQPassword),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQHostname),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQVHost),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQPort),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerExchangeName),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailQueueKey),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailRoutingKey),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailErrorQueueKey),
            SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailErrorRoutingKey));

        MailServerStatusManager.Instance.SetRabbitMQStatus(rabbitMQStatus);
        if (!rabbitMQStatus)
        {
            _log.Error("Rabbit MQ Connection error! Application Closing...");
            return;
        }

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        _log.Info("Starting filter....");
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<CoreServiceAuthorizeAttribute>();
            options.Filters.Add<CoreServiceFillRequestBaseActionFilterAttribute>();
        });

        _log.Info("Service filter ready.");


        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        MailServerStatusManager.Instance.SetServerStatus(true);
        app.Run();
    }
}

public class Settings
{
    public string SettingServerUrl { get; set; }
}