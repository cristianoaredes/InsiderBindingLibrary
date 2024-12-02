using Microsoft.UI.Xaml;
using Com.Useinsider.Insider;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AppExampleMaui.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
		this.InitializeComponent();
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	protected override void OnLaunched(LaunchActivatedEventArgs args)
	{
		base.OnLaunched(args);

		try
		{
			Insider.Instance.Init(null, "caaqui");

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
	}
}
