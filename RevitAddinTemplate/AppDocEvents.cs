using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
#if(UseDI)
using Microsoft.Extensions.Logging;
#endif
using System;

namespace RevitAddinTemplate
{
    internal class AppDocEvents
    {

#if(UseDI)
        private ILogger<AppDocEvents> _logger;

        public AppDocEvents()
        {
             _logger = Host.GetService<ILogger<AppDocEvents>>();
        }
#else
        public AppDocEvents()
        {
        }
#endif

        public void EnableEvents()
        {
            App.CachedUiCtrApp.Idling += new EventHandler<IdlingEventArgs>(OnIdling);
            App.CachedUiCtrApp.ViewActivated += new EventHandler<ViewActivatedEventArgs>(OnViewActivated);
            App.CachedUiCtrApp.ApplicationClosing += new EventHandler<ApplicationClosingEventArgs>(ApplicationClosing);


            App.CtrApp.DocumentClosed += OnDocumentClosed;
            App.CtrApp.DocumentOpened += OnDocumentOpened;
            App.CtrApp.DocumentSaved += OnDocumentSaved;
            App.CtrApp.DocumentSavedAs += OnDocumentSavedAs;
        }

        public void DisableEvents()
        {
            //App.CachedUiCtrApp.Idling -= OnIdling;
            //App.CachedUiCtrApp.ViewActivated -= OnViewActivated;

            App.CtrApp.DocumentClosed -= OnDocumentClosed;
            App.CtrApp.DocumentOpened -= OnDocumentOpened;
            App.CtrApp.DocumentSaved -= OnDocumentSaved;
            App.CtrApp.DocumentSavedAs -= OnDocumentSavedAs;
        }

        private void OnDocumentSavedAs(object sender, DocumentSavedAsEventArgs e)
        {
#if (UseDI)
            _logger.LogDebug("DocumentSavedAs");
#endif
        }

        private void OnDocumentSaved(object sender, DocumentSavedEventArgs e)
        {
#if (UseDI)
            _logger.LogDebug("DocumentSaved");
#endif
        }

        private void OnDocumentOpened(object sender, DocumentOpenedEventArgs e)
        {
#if (UseDI)
            _logger.LogDebug("DocumentOpened");
#endif
        }

        private void OnDocumentClosed(object sender, DocumentClosedEventArgs e)
        {
#if (UseDI)
            _logger.LogDebug("DocumentClosed");
#endif
        }

        private void OnIdling(object sender, IdlingEventArgs e)
        {

        }

        private void OnViewActivated(object sender, ViewActivatedEventArgs e)
        {
#if (UseDI)
            _logger.LogDebug("ViewActivated {view}", e.CurrentActiveView.Name);
#endif
        }

        private void ApplicationClosing(object sender, ApplicationClosingEventArgs e)
        {
#if (UseDI)
            _logger.LogDebug("ApplicationClosing");
#endif
        }
    }
}
