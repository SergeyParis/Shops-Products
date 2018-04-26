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
    }
}
