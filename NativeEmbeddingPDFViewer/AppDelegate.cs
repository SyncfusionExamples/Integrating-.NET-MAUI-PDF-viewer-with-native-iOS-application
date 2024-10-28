using Foundation;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.PdfViewer;
using UIKit;
using System.IO;
using System.Reflection;

namespace PDFViewerNativeEmbeddingiOS;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {

    private MauiContext? _mauiContext;
    public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
        builder.ConfigureSyncfusionCore();
        // Register the Window.
        builder.Services.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor(typeof(UIWindow), Window));
        MauiApp mauiApp = builder.Build();
        _mauiContext =new MauiContext(mauiApp.Services);
        // Create the PDF Viewer
        SfPdfViewer pdfViewer = new SfPdfViewer();
        pdfViewer.Background = Colors.White;
        // Load a PDF document
        var assembly = Assembly.GetExecutingAssembly();
        pdfViewer.DocumentSource = this.GetType().Assembly.GetManifestResourceStream("PDFViewerNativeEmbeddingiOS.Assets.PDF_Succinctly.pdf");           
        // Convert the .NET MAUI control to an iOS View object
        UIView mauiView = pdfViewer.ToPlatform(_mauiContext); mauiView.Frame = Window!.Frame;
        // Create UIViewController and add the PDF Viewer to its subviews
        var vc = new UIViewController();
        vc.View!.AddSubview(mauiView);
        // Set the UIViewController as the root view controller
        Window.RootViewController = vc;
        // Make the window visible
        Window.MakeKeyAndVisible();
        return
        true;
    }
}

