using log4net;
using Pavolle.BES.PasswordServer.Business.Manager;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.Core.Manager;

internal class Program
{
    private static void Main(string[] args)
    {
        var log4netRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        log4net.Config.XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));
        var builder = WebApplication.CreateBuilder(args);

        ILog _log = LogManager.GetLogger(typeof(Program));
        WebAppInfoManager.Instance.Initialize("Password Server", "1.0.0", "PASSE-PLLE-112326-TA", new DateTime(2023, 12, 6));

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
        if (settingServerStatus == null || !settingServerStatus.ServerStatus || !settingServerStatus.DbStatus)
        {
            _log.Error("Setting server is not active! Application closing!");
            return;
        }
        else
        {
            PasswordServerStatusManager.Instance.SetSettingServerConnectionStatus(true);
        }

        var dbStatus = PasswordServerDbManager.Instance.InitializeDb(SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection));
        PasswordServerStatusManager.Instance.SetDbStatus(dbStatus);


        // Add services to the container.

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}

public class Settings
{
    public string SettingServerUrl { get; set; }
}