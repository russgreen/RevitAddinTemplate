using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace RevitAddinTemplate
{
    [Transaction(TransactionMode.Manual)]
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

#if REVIT2021
#else
#endif

#if PREFORGETYPEID
#else
#endif

#if (UseWPF)
            var mainWindowView = new Views.MainView();
            mainWindowView.ShowDialog();            
#endif
#if (!UseWPF)
            //TODO: Remove reference to the Microsoft.Toolkit.MVVM package
            var form = new Forms.MainForm(commandData);
            form.ShowDialog(new WindowHandle(commandData.Application.MainWindowHandle));
#endif

            return Result.Succeeded;
        }


    }
}
