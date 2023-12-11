namespace EkapIhaleArama
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            /*
                Ekaptan bütün ihaleleri sorgulayacak.
                Ýhalelere göre uyarý gösterecek.
                Bu modülü daha sonra uygulama satýþý için de kullanabiliriz.
            Bu yüzden ekap ihale arama sürecini tamamen kütphane haline getirmemiz çok iyi olacaktýr.
             */
        }
    }
}