using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class DeleteBarCodeResponse
    {
        [XmlElement("delete_bar_codeResponse ")]
        public DeleteBarCodeResponseBody Body { get; set; }
    }

    public class DeleteBarCodeResponseBody
    {
        [XmlElement("delete_bar_codeResult")]
        public int Deleted { get; set; }
    }
}
