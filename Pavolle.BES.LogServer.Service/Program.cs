using log4net;
using Pavolle.BES.LogServer.Business.Manager;
using Pavolle.BES.LogServer.RabbitClient;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
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
        WebAppInfoManager.Instance.Initialize("Log Server", "1.0.1", "LRGOS-PLLE-112317-TA", new DateTime(2023, 11, 28));

        _log.Info("  ");
        _log.Info("********************************************");
        _log.Info("Pavolle - " + WebAppInfoManager.Instance.GetAppCode() + " ");
        _log.Info("Version Release Date => " + WebAppInfoManager.Instance.GetReleaseDate());
        _log.Info("App ID => " + WebAppInfoManager.Instance.GetId());
        _log.Info("********************************************");


        var settings = builder.Configuration.GetSection("Settings").Get<Settings>();
        _log.Info("Setting Server URL is " + settings.SettingServerUrl);


        SettingServiceManager.Instance.Initialize(settings.SettingServerUrl, WebAppInfoManager.Instance.GetAppCode(), WebAppInfoManager.Instance.GetId());
        var settingServerStatus= SettingServiceManager.Instance.GetServerStatus();
        if(settingServerStatus == null || !settingServerStatus.ServerStatus)
        {
            _log.Error("Setting server is not active! Application closing!");
            return;
        }
        else
        {
            LogServerStatusManager.Instance.SetSettingServerConnectionStatus(true);
        }

        bool rabbitMQStatus= RabbitMQManager.Instance.Initilize(
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQUsername),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQPassword),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQHostname),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQVHost),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQPort),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerExchangeName),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogQueueKey),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogRoutingKey),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogErrorQueueKey),
            SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogErrorRoutingKey));

        LogServerStatusManager.Instance.SetRabbitMQStatus(rabbitMQStatus);
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

        LogServerStatusManager.Instance.SetServerStatus(true);
        app.Run();
    }
}

public class Settings
{
    public string SettingServerUrl { get; set; }
}