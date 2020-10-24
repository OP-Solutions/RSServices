using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class GetBuyersWaybillsResponse
    {
        [XmlElement("get_buyer_waybillsResponse")]
        public GetBuyersWaybillsResponseBody ResponseBody { get; set; }
    }

    public class GetBuyersWaybillsResponseBody
    {
        [XmlElement("get_buyer_waybillsResult")]
        public GetBuyersWaybillsResult Result { get; set; }
    }

    public class GetBuyersWaybillsResult
    {
        [XmlElement("WAYBILL_LIST", Namespace = "")]
        public GetBuyersWaybillsResultList ListParent { get; set; }
    }

    public class GetBuyersWaybillsResultList
    {
        [XmlElement("WAYBILL")]
        public List<GetBuyersWaybillsResultElem> WaybillList { get; set; }
    }

    public class GetBuyersWaybillsResultElem
    {
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("TYPE")]
        public int Type { get; set; }

        [XmlElement("CREATE_DATE", IsNullable = true)]
        public DateTime? CreateDate { get; set; }

        [XmlElement("BUYER_TIN")]
        public string BuyerTin { get; set; }

        [XmlElement("BUYER_NAME")]
        public string BuyerName { get; set; }

        [XmlElement("SELLER_TIN")]
        public string SellerTin { get; set; }

        [XmlElement("SELLER_NAME")]
        public string SellerName { get; set; }

        [XmlElement("START_ADDRESS")]
        public string StartAddress { get; set; }

        [XmlElement("END_ADDRESS")]
        public string EndAddress { get; set; }

        [XmlElement("DRIVER_TIN")]
        public string DriverTin { get; set; }

        [XmlElement("TRANSPORT_COAST")]
        public double TransportCost { get; set; }
        
        [XmlElement("DRIVER_NAME")]
        public string DriverName { get; set; }
        
        [XmlElement("RECEPTION_INFO")]
        public string ReceptionInfo { get; set; }
        
        [XmlElement("RECEIVER_INFO")]
        public string ReceiverInfo { get; set; }
        
        [XmlElement("DELIVERY_DATE", IsNullable = true)]
        public DateTime? DeliveryDate { get; set; }
        
        [XmlElement("STATUS")]
        public int Status { get; set; }
        
        [XmlElement("ACTIVATE_DATE", IsNullable = true)]
        public DateTime? ActivateDate { get; set; }

        [XmlElement("PAR_ID")]
        public string ParId { get; set; }

        [XmlElement("FULL_AMOUNT")]
        public double FullAmount { get; set; }

        [XmlElement("CAR_NUMBER")]
        public string CarNumber { get; set; }
        
        [XmlElement("WAYBILL_NUMBER")]
        public string WaybillNumber { get; set; }

        [XmlElement("CLOSE_DATE", IsNullable = true)]
        public DateTime? CloseDate { get; set; }

        [XmlElement("S_USER_ID")]
        public string ServiceUserId { get; set; }
        
        [XmlElement("BEGIN_DATE", IsNullable = true)]
        public DateTime? BeginDate { get; set; }
        
        [XmlElement("WAYBILL_COMMENT")]
        public string WaybillComment { get; set; }
        
        [XmlElement("IS_CONFIRMED")]
        public int IsConfirmed { get; set; }

        [XmlElement("IS_CORRECTED")]
        public int IsCorrected { get; set; }
        
        [XmlElement("SELLER_ST")]
        public int SellerStatus { get; set; }
    }

}
