using Foundation;
using Com.Useinsider.Insider;

namespace AppExampleMaui;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        try
        {
            Insider.Instance.Init(application, "caaqui");

            if (Insider.Instance.IsSDKInitialized)
            {
                Insider.Instance.SetPushToken("teste");
            }
            else
            {
                // Handle SDK not initialized case
            }
        }
        catch (Exception ex)
        {
            // Log the exception details
            Console.WriteLine($"SDK Initialization Error: {ex.Message}");
            // Display a user-friendly error message
        }

        return base.FinishedLaunching(application, launchOptions);
    }
}
