using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Runtime.InteropServices;
#if (UseDI)
using Microsoft.Extensions.Logging;
#endif

namespace RevitAddinTemplate.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
#if (UseDI)
        private readonly ILogger<Command> _logger = Host.GetService<ILogger<Command>>();

#endif
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
#if (UseDI)
            _logger.LogDebug("Command called");

#endif
            if (commandData.Application.ActiveUIDocument.Document is null)
            {
                throw new ArgumentException("activedoc");
            }
            else
            {
                App.RevitDocument = commandData.Application.ActiveUIDocument.Document;
            }

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
