/*
 
        //Live support kullanýcýlarý teknik destek uygulama yönetiminde belirlenir.
        //Hizmet isteyen talep gönderebilir.
        //Bu talep canlý destek hizmeti veren kullanýcýlar arasýnda aktif hizmet veren kullanýcýlar arasýnda daðýtýlýr.
        //Daðýtým sýrasý tüm kiþileri bekleyen kayýt sayýsý sýralanýr. En az bekleyen olan kiþiye sýra numarasýna göre atanýr.
        //Bekleyen kiþi sayýsý ile ilgili bilgi verilir.
        //Hizmet veren kiþilerin performansý deðerlendirilir.
        //Bu Surrvey uygulamasý ile entegre çalýþacak þekilde yapýlýr.
 
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