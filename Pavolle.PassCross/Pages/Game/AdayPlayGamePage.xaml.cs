using Mopups.Services;
using Pavolle.Core.Enums;
using Pavolle.MobileCore.Manager;
using Pavolle.PassCross.Business;
using Pavolle.PassCross.Common.Enums;
using Pavolle.PassCross.Models;

namespace Pavolle.PassCross.Pages.Game;

public partial class AdayPlayGamePage : ContentPage
{
    SettingsDbModel _settings;
    QuestionModel _question;
    IDispatcherTimer _timer;
    int timeout = 20;

    public AdayPlayGamePage()
	{
		InitializeComponent();
        BackgroundImageSource = "back1.jpg";


        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(1000);
        _timer.Tick += (s, e) =>
        {
            timeout--;
            SureAciklama.Text = timeout.ToString();
            if(timeout < 5)
            {
                SureAciklamaBorder.BackgroundColor = Colors.DeepSkyBlue;
                SureAciklama.TextColor = Colors.IndianRed;
            }
            if(timeout == 0)
            {
                _timer.Stop();
                SureDoldu();
            }
        };
        _timer.Start();

        _settings = DbManager.Instance.GetSettings();

        MainObject.WidthRequest = SizeManager.Instance.GetRealSize(400);
        SureAciklama.FontSize = SizeManager.Instance.GetRealSize(22);
        SureAciklama.TextColor = Colors.White;
        entry1Object.FontSize = SizeManager.Instance.GetRealSize(22);
        entry2Object.FontSize = SizeManager.Instance.GetRealSize(22);
        AciklamaLabelObject.FontSize = SizeManager.Instance.GetRealSize(22);

        _question = GameManager.Instance.GenerateNewGame(EGameLevel.Aday, ELanguage.Turkish);

        tips1Object.Text = _question.Tips[0].Password+" => " + _question.Tips[0].Tip;
        tips2Object.Text = _question.Tips[1].Password + " => " + _question.Tips[1].Tip;
        tips3Object.Text = _question.Tips[2].Password + " => " + _question.Tips[2].Tip;

        tips1Object.FontSize = SizeManager.Instance.GetRealSize(18);
        tips2Object.FontSize = SizeManager.Instance.GetRealSize(18);
        tips3Object.FontSize = SizeManager.Instance.GetRealSize(18);
        OnaylaButton.WidthRequest = SizeManager.Instance.GetRealSize(150);
        OnaylaButton.FontSize = SizeManager.Instance.GetRealSize(18);
    }

    private void SureDoldu()
    {
        MopupService.Instance.PushAsync(new SureDolduPage(_question.Level, _question.Password, -10));
    }

    private void OnaylaButton_Clicked(object sender, EventArgs e)
    {
        _timer.Stop();
        string girilenSifre = entry1Object.Text + entry2Object.Text;
        if(girilenSifre == _question.Password)
        {
            MopupService.Instance.PushAsync(new BasariliPage());
        }
        else
        {
            MopupService.Instance.PushAsync(new HataliPage());
        }
    }

    private void entry1Object_TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry=(Entry)sender;
        if (entry.Text.Length == 1)
        {
            entry1Object.Unfocus();
            if (string.IsNullOrWhiteSpace(entry2Object.Text))
            {
                entry2Object.Focus();
            }

        }
    }

    private void entry2Object_TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        if (entry.Text.Length == 1)
        {
            //entry2Object.Unfocus();
        }
    }
}