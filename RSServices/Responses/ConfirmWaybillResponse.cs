using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class ConfirmWaybillResponse
    {
        [XmlElement("confirm_waybillResponse")]
        public ConfirmWaybillResponseBody Body { get; set; }
    }

    public class ConfirmWaybillResponseBody
    {
        [XmlElement("confirm_waybillResult")]
        public bool IsConfirmed { get; set; }
    }
}
