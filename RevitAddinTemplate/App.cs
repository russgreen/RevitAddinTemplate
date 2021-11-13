using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
//using Microsoft.AppCenter;
//using Microsoft.AppCenter.Analytics;
//using Microsoft.AppCenter.Crashes;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RevitAddinTemplate
{
    public class App : IExternalApplication
    {
        // get the absolute path of this assembly
        public static readonly string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        public static UIControlledApplication CachedUiCtrApp;
        public static UIApplication CachedUiApp;

        public static Autodesk.Revit.DB.Document RevitDocument;

        private readonly string _tabName = "Revit Addin Template";

        public Result OnStartup(UIControlledApplication application)
        {
            //start the application center monitoring - setup app on app center and uncomment thos code
            //AppCenter.LogLevel = LogLevel.Verbose;
            //System.Windows.Forms.Application.ThreadException += (sender, args) =>
            //{
            //    Crashes.TrackError(args.Exception);
            //};

            //AppCenter.Start("<APPGUID>", typeof(Crashes));

            CachedUiCtrApp = application;

            var panel = RibbonPanel(application);

            //application.Idling += new EventHandler<IdlingEventArgs>(OnIdling);
            //application.ViewActivated += new EventHandler<ViewActivatedEventArgs>(OnViewActivated);
            //application.ApplicationClosing += new EventHandler<ApplicationClosingEventArgs>(ApplicationClosing);

            return Result.Succeeded;
        }



        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }


        #region Event Handling
        private void OnIdling(object sender, IdlingEventArgs e)
        {
        }

        private void OnViewActivated(object sender, ViewActivatedEventArgs e)
        {
        }

        private void ApplicationClosing(object sender, ApplicationClosingEventArgs e)
        {
        }
        #endregion

        #region Ribbon Panel

        private RibbonPanel RibbonPanel(UIControlledApplication application)
        {
            try
            {
                CachedUiCtrApp.CreateRibbonTab(_tabName);
            }
            catch { }

            RibbonPanel panel = CachedUiCtrApp.CreateRibbonPanel(_tabName, "RevitAddin_Panel");
            panel.Title = "Revit addin";

            PushButtonData pbData = new PushButtonData("Command", "Command", Assembly.GetExecutingAssembly().Location, "RevitAddinTemplate.Command");
            PushButton pb = (PushButton)panel.AddItem(pbData);
            pb.ToolTip = "Tooltip text";
            pb.LargeImage = PngImageSource("RevitAddinTemplate.Resources.code-small.png");

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
