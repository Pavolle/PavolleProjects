using Pavolle.MobileCore.Common;

namespace Pavolle.PassCross.Page;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		this.companyNameObject.Text = AppInfoManager.Instance.GetAppFooter();
	}
}