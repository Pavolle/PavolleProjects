/*
 
        //Live support kullan�c�lar� teknik destek uygulama y�netiminde belirlenir.
        //Hizmet isteyen talep g�nderebilir.
        //Bu talep canl� destek hizmeti veren kullan�c�lar aras�nda aktif hizmet veren kullan�c�lar aras�nda da��t�l�r.
        //Da��t�m s�ras� t�m ki�ileri bekleyen kay�t say�s� s�ralan�r. En az bekleyen olan ki�iye s�ra numaras�na g�re atan�r.
        //Bekleyen ki�i say�s� ile ilgili bilgi verilir.
        //Hizmet veren ki�ilerin performans� de�erlendirilir.
        //Bu Surrvey uygulamas� ile entegre �al��acak �ekilde yap�l�r.
 
 */

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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