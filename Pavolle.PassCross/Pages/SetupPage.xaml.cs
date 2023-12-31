using Pavolle.MobileCore.Manager;
using Pavolle.PassCross.Business;
using Pavolle.PassCross.Models;

namespace Pavolle.PassCross.Pages;

public partial class SetupPage : ContentPage
{
    SettingsDbModel _settings;
    public SetupPage()
	{
		InitializeComponent();

        _settings = DbManager.Instance.GetSettings();
        FooterCopyRigthLabelObject.Text = AppInfoManager.Instance.GetAppFooterInfo(_settings.Language);
        FooterCopyRigthLabelObject.FontSize = SizeManager.Instance.GetRealSize(10);
    }
}