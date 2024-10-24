# Integrating .NET MAUI PDFViewer with native ios application
In this article, learn to use the .NET MAUI PDF viewer control in a native ios application and view a PDF document.

**Step 1:**

Create a new .NET ios Application and install the [Syncfusion.Maui.PdfViewer](https://www.nuget.org/packages/Syncfusion.Maui.PdfViewer) nuget package from [nuget.org](https://www.nuget.org/).

**Step 2:**

In the project file of the native application, add `<UseMaui>`true  `<UseMaui>` to enable the .Net Maui support demonstrated as follows. i.e. It tells the build system that your project is a .NET MAUI application and should be treated accordingly.
 
 ```xml
<PropertyGroup>
  <TargetFramework>net8.0-ios</TargetFramework>
  <OutputType>Exe</OutputType>
  <Nullable>enable</Nullable>
  <UseMaui>true</UseMaui>
  <ImplicitUsings>enable</ImplicitUsings>
  <SupportedOSPlatformVersion>13.0</SupportedOSPlatformVersion>
</PropertyGroup> 
 ```

**Step 3:**

To initialize .NET MAUI in a native app, create a MauiAppBuilder object and invoke **UseMauiEmbedding ()** to enable embedding. Then, configure it to setup **SyncfusionCore** component within your .NET native app project.

Then, create a MauiApp object by invoking the Build() method on the MauiAppBuilder object. In addition, a MauiContext object should be made from the MauiApp object. The MauiContext object will be used when converting .NET MAUI controls to native types.
 
 ```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
 {
      // create a new window instance based on the screen size
      Window = new UIWindow(UIScreen.MainScreen.Bounds);
      MauiAppBuilder builder = MauiApp.CreateBuilder();
      builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
      builder.ConfigureSyncfusionCore();

      // Register the Window.builder.Services.Add(new 
      Microsoft.Extensions.DependencyInjection.ServiceDescriptor(typeof(UIWindow), Window));
      MauiApp mauiApp = builder.Build();
      _mauiContext =new MauiContext(mauiApp.Services);

      ….
  } 
 ```

**Step 4:**

Create a folder named Assets in your project, add the required PDF file to this folder, and set the PDF file's build action to **Embedded resource** in its properties to view pdf in the SfPdfViewer control.

**Step 5:**

Initialize the SfPdfviewer control. Converts the SfPdfviewer control to a compatible ios UIView. Creates a UIViewController, adds the PdfViewer to its subview, and assigns it the root view controller of the main window. Makes the main window visible.

 
 ```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
    .....
    .....
    // Create the PDF Viewer
    SfPdfViewer pdfViewer = new SfPdfViewer();
    pdfViewer.Background = Colors.White;
    // Load a PDF document
    var assembly = Assembly.GetExecutingAssembly();
    pdfViewer.DocumentSource = this.GetType().Assembly.GetManifestResourceStream("PDFViewerNativeEmbeddingiOS.pdfSuc_1.pdf");
    
    // Convert the .NET MAUI control to an iOS View object
    UIView mauiView = pdfViewer.ToPlatform(_mauiContext); 
    mauiView.Frame = Window!.Frame;
    // Create UIViewController and add the PDF Viewer to its subviews
    var vc = new UIViewController();
    vc.View!.AddSubview(mauiView);
    // Set the UIViewController as the root view controller
    Window.RootViewController = vc;
    // Make the window visible
    Window.MakeKeyAndVisible();
    return true;
} 
 ```

**Step 6:**

In the solution, set the native ios project as the start-up project. Build, deploy and run the project.

[View the sample on GitHub](https://github.com/SyncfusionExamples/Integrating-.NET-MAUI-PDF-viewer-with-native-iOS-application)

We hope you enjoyed learning how to integrate .NET MAUI PDF Viewer in a native ios application.

Refer to our [.NET MAUI PDF Viewer’s feature tour](https://www.syncfusion.com/maui-controls/maui-pdf-viewer) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI PDF Viewer Documentation](https://help.syncfusion.com/maui/pdf-viewer/getting-started) to understand how to present and manipulate data.

For current customers, check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI PDF Viewer and other .NET MAUI components.

Please let us know in the following comments if you have any queries or require clarifications. You can also contact us through our [support forums](https://www.syncfusion.com/downloads/maui), [support ticket](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui). We are always happy to assist you!
