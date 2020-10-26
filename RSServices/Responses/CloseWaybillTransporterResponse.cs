using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class CloseWaybillTransporterResponse
    {
        [XmlElement("close_waybill_transporterResponse")]
        public CloseWaybillTransporterResponseBody Body { get; set; }
    }

    public class CloseWaybillTransporterResponseBody
    {
        [XmlElement("close_waybill_transporterResult")]
        public int Closed { get; set; }
    }
}
