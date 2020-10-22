using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class GetServiceUsersResponse
    {
        [XmlElement("get_service_usersResponse")]
        public GetServiceUsersResponseBody ResponseBody { get; set; }
    }


    public class GetServiceUsersResponseBody
    {
        [XmlElement("get_service_usersResult")]
        public GetServiceUsersResult Result { get; set; }
    }

    public class GetServiceUsersResult
    {
        [XmlElement("ServiceUsers", Namespace = "")]
        public GetServiceUsersResultList ListParent { get; set; }
    }

    public class GetServiceUsersResultList
    {
        [XmlElement("ServiceUser")]
        public List<GetServiceUsersResultElem> UsersList { get; set; }
    }

    public class GetServiceUsersResultElem
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("USER_NAME")]
        public string UserName { get; set; }

        [XmlElement("UN_ID")]
        public int UnId { get; set; }

        [XmlElement("IP")]
        public string Ip { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }
    }
}
