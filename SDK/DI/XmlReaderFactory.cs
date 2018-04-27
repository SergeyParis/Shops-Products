using System.IO;
using System.Xml;

namespace ShopsProducts.SDK
{
    internal static class XmlReaderFactory
    {
        public static XmlReader Reader { get; set; }

        public static XmlReader GetReader(string url)
        {
                if (Reader == null)
                    return XmlReader.Create(url);

            return Reader;
        }
        public static XmlReader GetReader(Stream input)
        {
            if (Reader == null)
                return XmlReader.Create(input);

            return Reader;
        }
        public static XmlReader GetReader(XmlNode input)
        {
            if (Reader == null)
                return new XmlNodeReader(input);

            return Reader;
        }
    }
}
