using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class RefWaybillResponse
    {
        [XmlElement("ref_waybillResponse")]
        public RefWaybillResponseBody Body { get; set; }
    }

    public class RefWaybillResponseBody
    {
        [XmlElement("ref_waybillResult")]
        public int RefWaybill { get; set; }
    }
}
