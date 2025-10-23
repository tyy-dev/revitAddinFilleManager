using Autodesk.Revit.UI;
using Autodesk.RevitAddIns;
using RevitAddinFilleManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace RevitAddinFilleManager.Extensions
{
    public static class XmlDocumentExtensions
    {
        extension(XmlDocument source)
        {
            public XmlNode? GetElementByAddinTag<T>(AddInTag<T> tag)
            {
                XmlNodeList? elements = source.GetElementsByTagName(tag.Tag);
                return elements?.Count > 0 ? elements[0]! : default;
            }

            public XmlNode CreateAndAppendElement(string nodeName)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(nameof(nodeName));

                return source.AppendChild(source.CreateElement(nodeName))!;
            }
        }
    }
}
