using Pavolle.MobileCore.Manager;
using Pavolle.PassCross.Business;
using Pavolle.PassCross.Models;
using Pavolle.PassCross.Pages.Game;

namespace Pavolle.PassCross.Pages;

public partial class MainPage : ContentPage
{
	SettingsDbModel _settings;
	public MainPage()
	{
		InitializeComponent();

		_settings = DbManager.Instance.GetSettings();
		FooterCopyRigthLabelObject.Text = AppInfoManager.Instance.GetAppFooterInfo(_settings.Language);
		FooterCopyRigthLabelObject.FontSize = SizeManager.Instance.GetRealSize(10);

    }

    private void PlayGameButton_Clicked(object sender, EventArgs e)
    {
		switch (_settings.CurrentLevel)
		{
			case Common.Enums.EGameLevel.Aday:
				Application.Current.MainPage = new AdayPlayGamePage();
				break;
			case Common.Enums.EGameLevel.Acemi:
				break;
			case Common.Enums.EGameLevel.Orta:
				break;
			case Common.Enums.EGameLevel.Tecrubeli:
				break;
			case Common.Enums.EGameLevel.Uzman:
				break;
			case Common.Enums.EGameLevel.Virtuoz:
				break;
			case Common.Enums.EGameLevel.Ustat:
				break;
			case Common.Enums.EGameLevel.Efsanevi:
				break;
			case Common.Enums.EGameLevel.UstunVarlik:
				break;
			default:
				break;
		}
	}
}