using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class DelWaybillResponse
    {
        [XmlElement("del_waybillResponse")]
        public DelWaybillResponseBody Body { get; set; }
    }

    public class DelWaybillResponseBody
    {
        [XmlElement("del_waybillResult")]
        public int Deleted { get; set; }
    }
}
