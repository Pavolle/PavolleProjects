using log4net;
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
        AppInfoManager.Instance.Initialize("Translate Server", "1.0.0", "TRTES-PLLE-112320-TA", new DateTime(2023, 11, 20));

        _log.Info("  ");
        _log.Info("********************************************");
        _log.Info("Pavolle - " + AppInfoManager.Instance.GetAppCode() + " ");
        _log.Info("Version Release Date => " + AppInfoManager.Instance.GetReleaseDate());
        _log.Info("App ID => " + AppInfoManager.Instance.GetId());
        _log.Info("********************************************");

        var settings = builder.Configuration.GetSection("Settings").Get<Settings>();
        _log.Info("Setting Server URL is " + settings.SettingServerUrl);
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        _log.Info("Starting filter....");
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<IntegrationAppAuthorizeAttribute>();
            options.Filters.Add<IntegrationAppFillRequestBaseActionFilterAttribute>();
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

        app.Run();
    }
}

public class Settings
{
    public string SettingServerUrl { get; set; }
}