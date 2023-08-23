using Newtonsoft.Json;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.ViewModels.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Message Service uygulama kurulumu başlatılıyor...");
      

        string[] text = File.ReadAllLines("appsettings.ini");
        MSSetupSettings items = new MSSetupSettings();
        items.ConnectionString = text[0];
        Console.WriteLine("Veritabanı bağlantısı yapılıyor. Connection String: " + text);

        bool dbConnectionResult=DbManager.Instance.InitDatabase(items.ConnectionString);
        if (dbConnectionResult)
        {
            Console.WriteLine("Veritabanı bağlantısı yapıldı. Yapılandırma başlatılıyor...");

            SetupManager.Instance.Setup(text[1], text[2], text[3], text[4], (int)ELanguage.Turkce);
            Console.WriteLine("Yazılım yapılandırma tamamlandı!");
        }
        else
        {
            Console.WriteLine("Veritabanı bağlantısı sağlanamadı!");
        }

    }
}