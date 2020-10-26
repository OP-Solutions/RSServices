using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class RefWaybillVdResponse
    {
        [XmlElement("ref_waybill_vdResponse")]
        public RefWaybillVdResponseBody Body { get; set; }
    }

    public class RefWaybillVdResponseBody
    {
        [XmlElement("ref_waybill_vdResult")]
        public int RefWaybillVd { get; set; }
    }
}
