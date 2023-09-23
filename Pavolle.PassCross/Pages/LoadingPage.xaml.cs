using Pavolle.Core.Enums;
using Pavolle.MobileCore.Manager;
using Pavolle.MobileCore.Models;
using Pavolle.PassCross.Business;
using Pavolle.PassCross.Models;

namespace Pavolle.PassCross.Pages;

public partial class LoadingPage : ContentPage
{
	Thread thread;
	SettingsDbModel _settings;
	bool loadingDone;
	public LoadingPage()
	{
		InitializeComponent();

		thread = new Thread(new ThreadStart(StartApplication));	
		thread.Start();


        IDispatcherTimer timer;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += (s, e) =>
        {
            if (_settings != null)
            {
                if (!_settings.SetupDone)
                {
                    Application.Current.MainPage = new SetupPage();
					timer.Stop();
					return;
                }
                else
                {
                    Application.Current.MainPage = new MainPage();
                    timer.Stop();
                    return;
                }
            }
        };
        timer.Start();

        
	}

    private void StartApplication()
    {
        _settings = DbManager.Instance.InitilaizeDb("Passcross");
		AppInfoManager.Instance.Initialize(new AppInfoModel
		{
			AppVersion = "1.0.0",
			AppNames = new List<AppNameModel>
			{
				new AppNameModel
				{
					Language=ELanguage.Turkish,
					AppName="PassCross"
				},
				new AppNameModel
				{
					Language =ELanguage.English,
					AppName="PassCross"
				}
			},
			Abouts = new List<AppAboutModel>
			{ 
				new AppAboutModel
				{
					Language=ELanguage.Turkish,
					About=new List<string>
					{

					}
				} ,
				new AppAboutModel 
				{ 
					Language=ELanguage.English, 
					About=new List<string> 
					{
					}
				}
			}
		});

        Thread.Sleep(2000);

		loadingDone = true;



    }
}