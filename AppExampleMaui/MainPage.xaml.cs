using Com.Useinsider.Insider;
using Serilog;
using System.Threading.Tasks;

namespace AppExampleMaui;

public partial class MainPage : ContentPage
{
    int count = 0;
    private const int MaxRetryAttempts = 3;
    private const int RetryDelayMilliseconds = 2000;

    public MainPage()
    {
        InitializeComponent();

#if ANDROID
        InitializeInsiderSDK();
#endif
    }

    private async void InitializeInsiderSDK()
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        int retryAttempts = 0;
        bool isInitialized = false;

        while (retryAttempts < MaxRetryAttempts && !isInitialized)
        {
            try
            {
                Insider.Instance.Init((Android.App.Application?)Android.App.Application.Context.ApplicationContext, "caaqui");

                if (Insider.Instance.IsSDKInitialized)
                {
                    Insider.Instance.SetPushToken("teste");
                    isInitialized = true;
                }
                else
                {
                    CounterBtn.Text = $"SDK Insider não iniciou.";
                    logger.Error("SDK Insider não iniciou.");
                }
            }
            catch (Exception ex)
            {
                retryAttempts++;
                logger.Error($"SDK Initialization Error: {ex.Message}. Retry attempt {retryAttempts}.");

                if (retryAttempts >= MaxRetryAttempts)
                {
                    CounterBtn.Text = $"SDK Initialization failed after {MaxRetryAttempts} attempts.";
                    logger.Error($"SDK Initialization failed after {MaxRetryAttempts} attempts.");
                }
                else
                {
                    await Task.Delay(RetryDelayMilliseconds);
                }
            }
        }
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
