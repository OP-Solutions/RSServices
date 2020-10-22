using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using RSServices.ResponseParams;

namespace RSServices
{
    public static class Helper
    {
        public static XNamespace Soap = "http://schemas.xmlsoap.org/soap/envelope/";

        public static HttpContent GetXmlBody(XDocument document)
        {
            return new StringContent(document.ToString(), Encoding.UTF8, "text/xml");
        }


        public static KeyValuePair<XDocument, XElement> GetNewDocument(string su, string sp, string requestName)
        {
            var document = new XDocument();

            var level1Elem1 = new XElement(Soap + "Envelope");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "soap", "http://schemas.xmlsoap.org/soap/envelope/");

            var level2Elem1 = new XElement(Soap + "Body");
            var level3Elem1 = new XElement(WaybillService.BaseNameSpace + requestName);

            level1Elem1.Add(level2Elem1);
            level2Elem1.Add(level3Elem1);


            var level4Elem1 = new XElement(WaybillService.BaseNameSpace + "su"){Value = su};
            var level4Elem2 = new XElement(WaybillService.BaseNameSpace + "sp"){Value = sp};

            level3Elem1.Add(level4Elem1);
            level3Elem1.Add(level4Elem2);

            document.Add(level1Elem1);

            return new KeyValuePair<XDocument, XElement>(document, level3Elem1);
        }

        public static XDocument GetServiceUsersXDocument(string userName, string password, string requestName)
        {
            var document = new XDocument();

            var level1Elem1 = new XElement(Soap + "Envelope");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema");
            level1Elem1.SetAttributeValue(XNamespace.Xmlns + "soap", "http://schemas.xmlsoap.org/soap/envelope/");

            var level2Elem1 = new XElement(Soap + "Body");
            var level3Elem1 = new XElement(WaybillService.BaseNameSpace + requestName);

            level1Elem1.Add(level2Elem1);
            level2Elem1.Add(level3Elem1);


            var level4Elem1 = new XElement(WaybillService.BaseNameSpace + "user_name") { Value = userName };
            var level4Elem2 = new XElement(WaybillService.BaseNameSpace + "user_password") { Value = password };

            level3Elem1.Add(level4Elem1);
            level3Elem1.Add(level4Elem2);

            document.Add(level1Elem1);

            return document;
        }

        public static CheckServiceUserResponse GetCheckServiceUserResponse(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(CheckServiceUserResponse));

            try
            {
                var response = (CheckServiceUserResponse)serializer.Deserialize(stream);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
