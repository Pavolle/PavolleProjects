using Mopups.Services;
using Pavolle.PassCross.Pages;

namespace Pavolle.PassCross
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}