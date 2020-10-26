using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class DeleteCarNumbersResponse
    {
        [XmlElement("delete_car_numbersResponse")]
        public DeleteCarNumbersResponseBody Body { get; set; }
    }

    public class DeleteCarNumbersResponseBody
    {
        [XmlElement("delete_car_numbersResult")]
        public int Delted { get; set; }
    }
}
