using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class RejectWaybillResponse
    {
        [XmlElement("reject_waybillResponse")]
        public RejectWaybillResponseBody Body { get; set; }
    }

    public class RejectWaybillResponseBody
    {
        [XmlElement("reject_waybillResult")]
        public bool IsRejected { get; set; }
    }
}
