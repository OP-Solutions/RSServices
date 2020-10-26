using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class CloseWaybillResponse
    {
        [XmlElement("close_waybillResponse")]
        public CloseWaybillResponseBody Body { get; set; }
    }

    public class CloseWaybillResponseBody
    {
        [XmlElement("close_waybillResult")]
        public int Closed { get; set; }
    }

   
}
