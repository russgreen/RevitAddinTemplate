using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
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
    public class App : IExternalApplication
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
        public Result OnStartup(UIControlledApplication application)
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
            ThisApp = this; 
            CachedUiCtrApp = application;
            CtrApp = application.ControlledApplication;

            var panel = RibbonPanel(application);

            AddAppDocEvents();

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            RemoveAppDocEvents();

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
                    "RevitAddinTemplate.Command"));
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
            catch
            {
                imageSource = null;
            }

            return imageSource;
        }
#endregion
    }
}
