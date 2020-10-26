using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class DeleteWaybillTemplateResponse
    {
        [XmlElement("delete_waybill_tamplateResponse")]
        public DeleteWaybillTemplateResponseBody Body { get; set; }
    }

    public class DeleteWaybillTemplateResponseBody
    {
        [XmlElement("delete_waybill_tamplateResult")]
        public int Deleted { get; set; }
    }
}
