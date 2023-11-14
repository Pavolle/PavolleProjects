using log4net;
using Pavolle.BES.SettingServer.Business;
using Pavolle.BES.SettingServer.Service.Filter;

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
        _log.Info("******** Pavolle - Settings Server *********");
        _log.Info("********************************************");
        _log.Info("  ");
        _log.Info("Uygulama baþlatýlýyor...");

        var settings = builder.Configuration.GetSection("Settings").Get<Settings>();

        bool dbConnection= DbManager.Instance.InitializeDb(settings.DbConnection);
        ServerStatusManager.Instance.SetDbStatus(dbConnection);
        if(!dbConnection)
        {
            _log.Error("Veritabaný baðlantýsý saðlanamadýðý için uygulama baþlatýlamadý.");
        }
        else
        {
            _log.Info("Kurulum ayarlarý kontrol ediliyor...");
            SetupManager.Instance.Initialize();
            _log.Info("Kurulum ayarlarý kontrol edildi");


            _log.Info("Sunucu için cache db çalýþtýrýlýyor...");
            SettingsServerManager.Instance.Initialize();
            _log.Info("Sunucu için cache db aktif");
        }

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<CustomAuthorizeAttribute>();
            options.Filters.Add<FillRequestBaseActionFilterAttribute>();
        });


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

        ServerStatusManager.Instance.SetSeverStatus(true);
        app.Run();
    }

    public class Settings
    {
        public string DbConnection { get; set; }
    }
}