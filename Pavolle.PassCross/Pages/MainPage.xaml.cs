using Pavolle.MobileCore.Manager;
using Pavolle.PassCross.Business;
using Pavolle.PassCross.Models;

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
}