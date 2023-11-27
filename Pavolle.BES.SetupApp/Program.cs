using Pavolle.BES.SetupApp;
using System.Text.Json;
using System.Text.Json.Nodes;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Pavolle - BES uygulama kurulumu başlatılıyor!");
        Console.WriteLine("Kurulum ayarları dosyadan okunuyor...!");

        string setupData = File.ReadAllText("settings.json");

        Console.WriteLine("Kurulum Ayarlar: => ");

        Console.WriteLine(setupData);

        Console.WriteLine("Ayarları onaylıyor musunuz? E=>evet , H =>hayır");
        string data;
        data = Console.ReadLine();

        if (data.ToLower() == "e")
        {
            Console.WriteLine("Kurulum başlatılıyor...");

            SetupSettings settings=JsonSerializer.Deserialize<SetupSettings>(setupData);

            Console.WriteLine("Kurulum Tamamlandı.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Kurulum başlatılamadı! Uygulama kapatılıyor...");
        }




        //Dosydan okunan şifre bilgisine göre veritabanı için şifre oluşturulacak. Bu şifre sadece bizim algoritmamızdan geçerek oluşturulabilecek.
        //json dosyasından ayarları okuyarak uygulama oluşturulacak.
        //system admin ekle
        //

        //Veritabanı bağlantısını yap
        //Uygulama kurulum ayar dosyasını oku.
        //Bu ayar dosyasına göre uygulama kurulumlarını yap.
    }
}