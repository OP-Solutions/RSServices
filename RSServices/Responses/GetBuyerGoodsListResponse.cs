using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RSServices.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class GetBuyerGoodsListResponse
    {
        [XmlElement("get_buyer_waybilll_goods_listResponse")]
        public GetBuyerGoodsListResponseBody Body { get; set; }
    }

    public class GetBuyerGoodsListResponseBody
    {
        [XmlElement("get_buyer_waybilll_goods_listResult")]
        public GetBuyerGoodsListResult Result { get; set; }
    }

    public class GetBuyerGoodsListResult
    {

    }

    public class GetBuyersGoodsListResultElems
    {

    }

    public class GetBuyersGoodsListResultElem
    {

    }
}
