using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.ResponseParams
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class CheckServiceUserResponse
    {
        [XmlElement("chek_service_userResponse")]
        public CheckServiceUserResponseBody Body { get; set; }
    }



   public class CheckServiceUserResponseBody
   {
       [XmlElement("chek_service_userResult")]
       public bool Result { get; set; }

       [XmlElement("un_id")]
       public int UnId { get; set; }

       [XmlElement("s_user_id")]
       public int UserId { get; set; }
    }
}
