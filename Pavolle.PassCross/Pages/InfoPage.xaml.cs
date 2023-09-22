using Mopups.Pages;
using Mopups.Services;

namespace Pavolle.PassCross.Pages;

public partial class InfoPage : PopupPage
{
	public InfoPage()
	{
		InitializeComponent();
	}

    private void blahButton_Clicked(object sender, EventArgs e)
    {
		MopupService.Instance.PopAsync();
    }
}