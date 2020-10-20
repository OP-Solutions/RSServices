using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using RSServices.ResponseParams;

namespace RSServices
{
    public class Helper
    {

        public static HttpContent GetXmlBody(XDocument document)
        {
            return new StringContent(document.ToString(), Encoding.UTF8, "text/xml");
        }


        public static KeyValuePair<XDocument, XElement> GetNewDocument(string su, string sp, string requestName)
        {
            var soap = (XNamespace)"http://schemas.xmlsoap.org/soap/envelope/";

            var document = new XDocument();

            var level1Elem1 = new XElement(soap + "Envelope");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "soap", "http://schemas.xmlsoap.org/soap/envelope/");

            var level2Elem1 = new XElement(soap + "Body");
            var level3Elem1 = new XElement(WaybillService.BaseNameSpace + requestName);

            level1Elem1.Add(level2Elem1);
            level2Elem1.Add(level3Elem1);

            var level4Elem1 = new XElement($"{WaybillService.BaseNameSpace}{su}");
            var level4Elem2 = new XElement($"{WaybillService.BaseNameSpace}{sp}");

            level3Elem1.Add(level4Elem1);
            level3Elem1.Add(level4Elem2);

            document.Add(level1Elem1);

            return new KeyValuePair<XDocument, XElement>(document, level3Elem1);
        }

        public static CheckServiceUserResponse GetCheckServiceUserResponse(Stream stream)
        {
            throw new NotImplementedException();
        }

    }
}
