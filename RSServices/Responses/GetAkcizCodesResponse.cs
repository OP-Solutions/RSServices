using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class GetAkcizCodesResponse
    {
        [XmlElement("get_akciz_codesResponse")]
        public GetAkcizCodesResponseBody ResponseBody { get; set; }
    }

    public class GetAkcizCodesResponseBody
    {
        [XmlElement("get_akciz_codesResult")]
        public GetAkcizCodesResult Result { get; set; }
    }

    public class GetAkcizCodesResult
    {
        [XmlElement("AKCIZ_CODES", Namespace = "")]
        public GetAkcizCodesResultList ListParent { get; set; }
    }

    public class GetAkcizCodesResultList
    {
        [XmlElement("AKCIZ_CODE")]
        public List<GetAkcizCodesResultElem> CodesList { get; set; }
    }

    public class GetAkcizCodesResultElem
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("TITLE")]
        public string Title { get; set; } 

        [XmlElement("MEASUREMENT")]
        public string Measurement { get; set; }

        [XmlElement("SAKON_KODI")]
        public string AkcizCode { get; set; }

        [XmlElement("AKCIS_GANAKV")]
        public double AkcizRate { get; set; }

        [XmlElement("START_DATE", IsNullable = true)]
        public DateTime? StartDate { get; set; }

        [XmlElement("END_DATE", IsNullable = true)]
        public DateTime? EndDate { get; set; }
    }
}
