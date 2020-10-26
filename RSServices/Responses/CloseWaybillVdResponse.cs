using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot("http://tempuri.org/")]
    public class CloseWaybillVdResponse
    {
        [XmlElement("close_waybill_vdResponse")]
        public CloseWaybillVdResponseBody Body { get; set; }
    }

    public class CloseWaybillVdResponseBody
    {
        [XmlElement("close_waybill_vdResult")]
        public int Closed { get; set; }
    }
}
