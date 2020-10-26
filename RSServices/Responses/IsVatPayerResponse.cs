using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class IsVatPayerResponse
    {
        [XmlElement("is_vat_payerResponse")]
        public IsVatPayerResponseBody Body { get; set; }
    }

    public class IsVatPayerResponseBody
    {
        [XmlElement("is_vat_payerResult")]
        public bool IsVatPayer { get; set; }
    }
}
