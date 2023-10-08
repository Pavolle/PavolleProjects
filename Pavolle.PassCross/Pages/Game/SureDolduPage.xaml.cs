using Mopups.Pages;
using Mopups.Services;
using Pavolle.PassCross.Common.Enums;

namespace Pavolle.PassCross.Pages.Game;

public partial class SureDolduPage : PopupPage
{
	EGameLevel _level;
	public SureDolduPage(EGameLevel level, string dogruCevap, int eksilecekPuand)
	{
		_level = level;
		InitializeComponent();
	}

    private void button_Clicked(object sender, EventArgs e)
    {
		switch (_level)
		{
			case EGameLevel.Aday:
				Application.Current.MainPage=new AdayPlayGamePage();
				break;
			case EGameLevel.Acemi:
				break;
			case EGameLevel.Orta:
				break;
			case EGameLevel.Tecrubeli:
				break;
			case EGameLevel.Uzman:
				break;
			case EGameLevel.Virtuoz:
				break;
			case EGameLevel.Ustat:
				break;
			case EGameLevel.Efsanevi:
				break;
			case EGameLevel.UstunVarlik:
				break;
			default:
				break;
		}
		MopupService.Instance.PopAsync();
    }
}