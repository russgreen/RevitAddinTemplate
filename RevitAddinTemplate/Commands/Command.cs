using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Runtime.InteropServices;
#if (UseDI)
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit.External;
#endif

namespace RevitAddinTemplate.Commands
{
    [Transaction(TransactionMode.Manual)]

#if (UseDI)
    public class Command : ExternalCommand
    {
        private ILogger<Command> _logger;

        public override void Execute()
        {

            _logger = Host.GetService<ILogger<Command>>();

            _logger.LogDebug("Command called");

            App.RevitDocument = Context.UiDocument.Document;
            App.CachedUiApp = Context.UiApplication;

#else
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        { 

            if (commandData.Application.ActiveUIDocument.Document is null)
            {
                throw new ArgumentException("activedoc");
            }
            else
            {
                App.RevitDocument = commandData.Application.ActiveUIDocument.Document;
            }
#endif


#if REVIT2020 || REVIT2021 || REVIT2022
#else
#endif

#if REVIT2021
#else
#endif

#if REVIT2022_OR_GREATER
#else
#endif

#if PREFORGETYPEID
#else
#endif

#if (UseWPF)
            var mainWindowView = new Views.MainView();
            mainWindowView.ShowDialog();
#endif

            return Result.Succeeded;
        }


    }
}
