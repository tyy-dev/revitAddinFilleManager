using Autodesk.Revit.DB;
using Autodesk.RevitAddIns;
using RevitAddinFilleManager.Entities;
using RevitAddinFilleManager.Entities.Enums;
using System.Reflection;
using System.Xml;

namespace RevitAddinFilleManager.Extensions
{
    public static class AddInItemExtensions
    {
        // Base extension for all RevitAddInItem
        extension(RevitAddInItem source)
        {
            public AddInTag<T> GetAddInTag<T>(AddInTag<T> tag)
            {
                XmlDocument xml = source.ToXmlDocument();

                string? value = xml.GetElementByAddinTag(tag)?.InnerText;
                return tag with { Value = value };
            }

            public XmlDocument ToXmlDocument()
            {
                XmlDocument document = new();
                XmlNode addInNode = document.CreateAndAppendElement("AddIn");

                addInNode.CreateAndAppendElement("Assembly", source.Assembly);
                addInNode.CreateAndAppendElement("AddInId", source.AddInId.ToString());
                addInNode.CreateAndAppendElement("FullClassName", source.FullClassName);

                addInNode.CreateAndAppendElement("VendorId", source.VendorId);
                addInNode.CreateAndAppendElement("VendorDescription", source.VendorDescription);

                addInNode.CreateAndAppendElement("ProductImage", source.ProductImage);
                addInNode.CreateAndAppendElement("ProductDescription", source.ProductDescription);
                addInNode.CreateAndAppendElement("ProductVersion", source.ProductVersion);

                addInNode.CreateAndAppendElement("AllowLoadingIntoExistingSession", source.AllowLoadingIntoExistingSession.ToString());

                switch (source)
                {
                    case RevitAddInCommand command:
                        addInNode.CreateAndAppendAttribute("Type", "Command");

                        addInNode.CreateAndAppendElement("Text", command.Text);
                        addInNode.CreateAndAppendElement("Description", command.Description);
                        addInNode.CreateAndAppendElement("LongDescription", command.LongDescription);
                        addInNode.CreateAndAppendElement("LargeImage", command.LargeImage);
                        addInNode.CreateAndAppendElement("TooltipImage", command.TooltipImage);
                        addInNode.CreateAndAppendElement("VisibilityMode", command.VisibilityMode.ToString());
                        addInNode.CreateAndAppendElement("Discipline", command.Discipline.ToString());
                        addInNode.CreateAndAppendElement("AvailabilityClassName", command.AvailabilityClassName);
                        addInNode.CreateAndAppendElement("LanguageType", command.LanguageType.ToString());;
                        break;
                    case RevitAddInApplication app:
                        addInNode.CreateAndAppendAttribute("Type", "Application");
                        addInNode.CreateAndAppendElement("Name", app.Name);
                        break;
                    case RevitAddInDBApplication dbApp:
                        addInNode.CreateAndAppendAttribute("Type", "DBApplication");

                        addInNode.CreateAndAppendElement("Name", dbApp.Name);
                        addInNode.CreateAndAppendElement("LoadInRevitWorker", dbApp.LoadInRevitWorker.ToString());
                        break;
                }

                return document;
            }
        }
    }
}
