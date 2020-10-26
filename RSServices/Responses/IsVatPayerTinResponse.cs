using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class IsVatPayerTinResponse
    {
        [XmlElement("is_vat_payer_tinResponse")]
        public IsVatPayerTinResponseBody Body { get; set; }
    }

    public class IsVatPayerTinResponseBody
    {
        [XmlElement("is_vat_payer_tinResult")]
        public bool IsVatPayerTin { get; set; }
    }

}
