using log4net;
using Pavolle.BES.SettingServer.Business;
using Pavolle.BES.WebFilter;
using Pavolle.Core.Manager;

internal class Program
{
    private static void Main(string[] args)
    {
        var log4netRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        log4net.Config.XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));
        var builder = WebApplication.CreateBuilder(args);

        AppInfoManager.Instance.Initialize("Settings Server", "1.1.0", "SESER-PLLE-112317-TA", new DateTime(2023, 11, 17));

        ILog _log = LogManager.GetLogger(typeof(Program));

        _log.Info("  ");
        _log.Info("********************************************");
        _log.Info("Pavolle - "+ AppInfoManager.Instance.GetAppCode() + " ");
        _log.Info("Version Release Date => " + AppInfoManager.Instance.GetReleaseDate());
        _log.Info("App ID => " + AppInfoManager.Instance.GetId());
        _log.Info("********************************************");


        var settings = builder.Configuration.GetSection("Settings").Get<Settings>();

        bool dbConnection= DbManager.Instance.InitializeDb(settings.DbConnection);
        ServerStatusManager.Instance.SetDbStatus(dbConnection);
        if(!dbConnection)
        {
            _log.Error("Db connection error! Db is not ready!");
            return;
        }
        else
        {
            _log.Info("Checking setup configuration...");
            SetupManager.Instance.Initialize();
            _log.Info("Setup configuration done.");


            _log.Info("Starting settings cache server...");
            SettingsServerManager.Instance.Initialize();
            _log.Info("Settings Cache DB is ready");
        }

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
        //if (app.Environment.IsDevelopment())
        //{
        //}
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        ServerStatusManager.Instance.SetSeverStatus(true);
        _log.Info("Settings Server is Ready");
        app.Run();
    }

    public class Settings
    {
        public string DbConnection { get; set; }
    }
}