using System;
using System.Collections.Generic;
using System.Text;

namespace RSServices.RequestParams
{
    public class CloseWaybillTransporterParams
    {
        public int WaybillId { get; set; }

        public string ReceptionInfo { get; set; }

        public string ReceiverInfo { get; set; }

        public DateTime? deliveryDate { get; set; }
    }
}
