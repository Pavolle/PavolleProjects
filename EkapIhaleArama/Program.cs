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
                Ekaptan b�t�n ihaleleri sorgulayacak.
                �halelere g�re uyar� g�sterecek.
                Bu mod�l� daha sonra uygulama sat��� i�in de kullanabiliriz.
            Bu y�zden ekap ihale arama s�recini tamamen k�tphane haline getirmemiz �ok iyi olacakt�r.
             */
        }
    }
}