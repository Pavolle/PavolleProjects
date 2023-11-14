using log4net;
using Pavolle.BES.LogServer.Business.Manager;
using Pavolle.BES.LogServer.RabbitClient;
using Pavolle.BES.LogServer.Service.Filter;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        var log4netRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        log4net.Config.XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));
        var builder = WebApplication.CreateBuilder(args);

        ILog _log = LogManager.GetLogger(typeof(Program));

        _log.Info("  ");
        _log.Info("********************************************");
        _log.Info("********** Pavolle - Log Server ************");
        _log.Info("********************************************");
        _log.Info("  ");
        _log.Info("Application starting...");


        var settings = builder.Configuration.GetSection("Settings").Get<Settings>();
        _log.Info("Setting Server URL is " + settings.SettingServerUrl);
        SettingServiceManager.Instance.Initialize(settings.SettingServerUrl);
        var settingServerStatus= SettingServiceManager.Instance.GetServerStatus();
        if(settingServerStatus == null || !settingServerStatus.ServerStatus || !settingServerStatus.DbStatus)
        {
            _log.Error("Setting server is not active! Application closing!");
            return;
        }
        else
        {
            LogServerStatusManager.Instance.SetSettingServerConnectionStatus(true);
        }

        bool initializeStatus = LogServerManager.Instance.InitializeSettings();
        LogServerStatusManager.Instance.SetSettingServerConnectionStatus(initializeStatus);
        if (!initializeStatus)
        {
            _log.Error("Fetch settings from Setting Server error. Application Closing...");
            return;
        }

        bool rabbitMQStatus= RabbitMQManager.Instance.Initilize(
            LogServerManager.Instance.GetSetting(ESettingType.LogServerRabbitMQUsername),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerRabbitMQPassword),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerRabbitMQHostname),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerRabbitMQVHost),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerRabbitMQPort),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerExchangeName),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerLogQueueKey),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerLogRoutingKey),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerLogErrorQueueKey),
            LogServerManager.Instance.GetSetting(ESettingType.LogServerLogErrorRoutingKey));

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
            options.Filters.Add<CustomAuthorizeAttribute>();
            options.Filters.Add<FillRequestBaseActionFilterAttribute>();
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