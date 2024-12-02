using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Com.Useinsider.Insider;

namespace AppExampleMaui;

class Program : MauiApplication
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static void Main(string[] args)
    {
        var app = new Program();
        app.Run(args);
    }

    protected override void OnCreate()
    {
        base.OnCreate();

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
