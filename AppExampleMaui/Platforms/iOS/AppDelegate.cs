using Foundation;
using InsiderBindingLibrary;

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

                // Get content optimizer values
                string contentOptimizerString = Insider.Instance.GetContentStringWithName("string_variable_name", "defaultValue", ContentOptimizerDataType.Element);
                Console.WriteLine($"[getContentStringWithName]: {contentOptimizerString}");

                bool contentOptimizerBool = Insider.Instance.GetContentBoolWithName("bool_variable_name", true, ContentOptimizerDataType.Element);
                Console.WriteLine($"[getContentBoolWithName]: {contentOptimizerBool}");

                int contentOptimizerInt = Insider.Instance.GetContentIntWithName("int_variable_name", 10, ContentOptimizerDataType.Element);
                Console.WriteLine($"[getContentIntWithName]: {contentOptimizerInt}");
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
