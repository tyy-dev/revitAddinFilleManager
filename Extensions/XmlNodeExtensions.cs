using RevitAddinFilleManager.Entities;
using System.Reflection.Metadata;
using System.Xml;

namespace RevitAddinFilleManager.Extensions
{
    public static class XmlNodeExtensions
    {
        extension(XmlNode source)
        {

            public XmlNode CreateAndAppendAttribute<T>(string nodeName, T value)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(nameof(nodeName));

                XmlDocument? document = source.OwnerDocument;
                ArgumentNullException.ThrowIfNullOrEmpty(nameof(document), "Cannot create a attribute because the XmlNode does not belong to any XmlDocument.");

                XmlAttribute attribute = document!.CreateAttribute(nodeName);

                if (value is not null)
                    attribute.Value = value.ToString();

                return source?.Attributes?.Append(attribute)!;
            }

            public XmlNode CreateAndAppendElement(string nodeName, string innerText)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(nameof(nodeName));

                XmlDocument? document = source.OwnerDocument;
                ArgumentNullException.ThrowIfNullOrEmpty(nameof(document), "Cannot create a child element because the XmlNode does not belong to any XmlDocument.");

                XmlNode element = source.AppendChild(document!.CreateElement(nodeName))!;
                element.InnerText = innerText;

                return element;
            }
        }
    }
}
