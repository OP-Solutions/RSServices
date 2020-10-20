using System;
using System.Collections.Generic;
using System.Text;

namespace RSServices.ResponseParams
{
    public class CheckServiceUserResponse
    {
        public bool? Result { get; set; }

        public int? UnId { get; set; }

        public int? UserId { get; set; }

        public int? ErrorCode { get; set; }
    }
}
