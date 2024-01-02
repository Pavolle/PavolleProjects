using log4net;
using Pavolle.BES.GeoServer.Business.Manager;
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
        WebAppInfoManager.Instance.Initialize("Geolocation Server", "1.0.0", "JEOSR-PLLE-012301-TA", new DateTime(2023, 1, 1));

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
            GeoServerStatusManager.Instance.SetSettingServerConnectionStatus(true);
        }


        bool dbConnection = GeoServerDbManager.Instance.InitializeDb(SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection));
        GeoServerStatusManager.Instance.SetDbStatus(dbConnection);
        if (!dbConnection)
        {
            _log.Error("Db connection error! Db is not ready!");
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

        GeoServerStatusManager.Instance.SetServerStatus(true);
        app.Run();
    }
}

public class Settings
{
    public string SettingServerUrl { get; set; }
}