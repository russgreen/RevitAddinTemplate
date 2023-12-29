using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
#if (UseDI)
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit.External;
#endif
using Autodesk.Revit.UI.Events;
using RevitAddinTemplate.Commands;
using System;
#if (UseAnalytics)
//uncomment references to Microsoft.AppCenter.Analytics and Microsoft.AppCenter.Crashes in .csproj
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
#endif
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RevitAddinTemplate
{
#if (UseDI)
    public class App : ExternalApplication
#else
    public class App : IExternalApplication
#endif
    {
        // get the absolute path of this assembly
        public static readonly string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        // class instance
        public static App ThisApp;

        public static UIControlledApplication CachedUiCtrApp;
        public static UIApplication CachedUiApp;
        public static ControlledApplication CtrApp;
        public static Autodesk.Revit.DB.Document RevitDocument;

        private AppDocEvents _appEvents;
#if (CreateNewRibbonTab)
        private readonly string _tabName = "RevitAddinTemplate";

#endif
#if (UseDI)
        private ILogger<App> _logger;

        public override void OnStartup()
#else
        public Result OnStartup(UIControlledApplication application)
#endif
        {
#if (UseAnalytics)
            //start the application center monitoring - setup app on https://appcenter.ms/
            AppCenter.LogLevel = LogLevel.Verbose;
            System.Windows.Forms.Application.ThreadException += (sender, args) =>
            {
                Crashes.TrackError(args.Exception);
            };

            AppCenter.Start("<APPGUID>", typeof(Crashes));

#endif
#if (UseDI)
            ThisApp = this; 
            CachedUiCtrApp = Application;
            CtrApp = Application.ControlledApplication;

            Host.StartHost();

            _logger = Host.GetService<ILogger<App>>();
#else
            ThisApp = this; 
            CachedUiCtrApp = application;
            CtrApp = application.ControlledApplication;
#endif

            var panel = RibbonPanel(CachedUiCtrApp);

            AddAppDocEvents();

#if (!UseDI)
            return Result.Succeeded;
#endif
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            RemoveAppDocEvents();

#if (UseDI)
            Host.StopHost();
            Serilog.Log.CloseAndFlush();

#endif
            return Result.Succeeded;
        }

        #region Event Handling
        private void AddAppDocEvents()
        {
            _appEvents = new AppDocEvents();
            _appEvents.EnableEvents();
        }
        private void RemoveAppDocEvents()
        {
            _appEvents.DisableEvents();
        }


#endregion

#region Ribbon Panel

        private RibbonPanel RibbonPanel(UIControlledApplication application)
        {

#if (CreateNewRibbonTab)
            try
            {
                CachedUiCtrApp.CreateRibbonTab(_tabName);
            }
            catch { }

            RibbonPanel panel = CachedUiCtrApp.CreateRibbonPanel(_tabName, "RevitAddinTemplate_Panel");
#else
            RibbonPanel panel = CachedUiCtrApp.CreateRibbonPanel("RevitAddinTemplate_Panel");
#endif
            panel.Title = "RevitAddinTemplate";

            PushButton button = (PushButton)panel.AddItem(
                new PushButtonData(
                    "Command", 
                    "Command", 
                    Assembly.GetExecutingAssembly().Location,
                    $"{nameof(RevitAddinTemplate)}.{nameof(Commands)}.{nameof(Command)}"));
            button.ToolTip = "Execute the RevitAddinTemplate command";
            button.LargeImage = PngImageSource("RevitAddinTemplate.Resources.RevitAddinTemplate_Button.png");

            return panel;
        }

        private System.Windows.Media.ImageSource PngImageSource(string embeddedPath)
        {
            var stream = GetType().Assembly.GetManifestResourceStream(embeddedPath);
            System.Windows.Media.ImageSource imageSource;
            try
            {
                imageSource = BitmapFrame.Create(stream);
            }
            catch(Exception ex)
            {
#if (UseDI)
                _logger.LogError(ex, "Error loading image from embedded resource");
#endif
                imageSource = null;
            }

            return imageSource;
        }
#endregion
    }
}
