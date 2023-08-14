using Pavolle.Core.Helper;
using Pavolle.PassCross.Business;
using Pavolle.PassCross.Page;
using Pavolle.PassCross.Page.Game;
using Pavolle.PassCross.Page.Game.Aday;

namespace Pavolle.PassCross
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //GameManager.Instance.YeniSoruOlustur(Enums.ELevel.Aday, Core.Enums.ELanguage.Turkce);
            //Aday seviyesi için soru hazırlandı. Buna göre tasarıma geçebiliriz.
            MainPage = new AdayPlayGamePage();
        }
    }
}