using System;
using System.Collections.Generic;
using System.Text;

namespace RSServices.RequestParams
{
    public class BuyerWaybillParams
    {
        public string ITypes { get; set; }
        public string SellerTin { get; set; }
        public string Statuses { get; set; }
        public string CarNumber { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateDateStart { get; set; }
        public DateTime? CreateDateEnd { get; set; }
        public string DriverTin { get; set; }
        public DateTime? DeliveryDateStart { get; set; }
        public DateTime? DeliveryDateEnd { get; set; }
        public decimal? FullAmount { get; set; }
        public string WaybillNumber { get; set; }
        public DateTime? CloseDateStart { get; set; }
        public DateTime? CloseDateEnd { get; set; }
        public string SUserIds { get; set; }
        public string Comment { get; set; }
    }
}
