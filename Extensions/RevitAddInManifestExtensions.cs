using Autodesk.RevitAddIns;
using System.Xml;

namespace RevitAddinFilleManager.Extensions
{
    public static class RevitAddInManifestExtensions
    {
        extension(RevitAddInManifest source)
        {
            public List<RevitAddInItem> AddinItems => [.. source.AddInCommands, .. source.AddInApplications, .. source.AddInDBApplications];

            public XmlDocument ToXmlDocument()
            {
                XmlDocument document = new();
                XmlNode revitAddInsNode = document.CreateAndAppendElement("RevitAddIns");

                foreach (RevitAddInItem addinItem in source.AddinItems)
                {
                    XmlNode addInItemNode = document.ImportNode(addinItem.ToXmlDocument().DocumentElement!, true);
                    revitAddInsNode.AppendChild(addInItemNode);
                }
                return document;
            }
            public RevitAddInItem? GetRevitAddInItemByFullClassName(string fullClassName) => source.AddinItems
                      .FirstOrDefault(a => a.FullClassName == fullClassName);

        }
    }
}
