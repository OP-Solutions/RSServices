using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class CreateServiceUserResponse
    {
        [XmlElement("create_service_userResponse")]
        public CreateServiceUserResponseBody Body { get; set; }
    }

    public class CreateServiceUserResponseBody
    {
        [XmlElement("create_service_userResult")]
        public bool Result { get; set; }
    }
}
