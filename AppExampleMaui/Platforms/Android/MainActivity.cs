using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Useinsider.Insider;

namespace AppExampleMaui;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        try
        {
            Insider.Instance.Init((Android.App.Application?)ApplicationContext, "caaqui");

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
    }
}
