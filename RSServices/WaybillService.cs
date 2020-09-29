using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RSServices
{
    public class WaybillService
    {
        private const string ContentType = "";

        public static readonly XNamespace BaseNameSpace = "http://tempuri.org/";

        //will fill with requests implemented
        private readonly Dictionary<RequestNames, string> _requests = new Dictionary<RequestNames, string>()
        {
            {RequestNames.CheckServiceUser, "chek_service_user"}
        };

        enum RequestNames
        {
            CheckServiceUser
        }



        private HttpClient _client;

        public WaybillService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://services.rs.ge/WayBillService/WayBillService.asmx"),
            };
        }

        /// <summary>
        /// checks if given <paramref name="su"/> and <paramref name="sp"/> is valid
        /// </summary>
        /// 
        /// <returns>true if su and sp was valid, false otherwise</returns>
        public async Task<bool> CheckServiceUserAsync(string su, string sp)
        {
            var pair = Helper.GetNewDocument(_requests[RequestNames.CheckServiceUser]);
            var lastChild = pair.Value;

            var arg1 = new XElement(BaseNameSpace + "su"){Value = su};
            var arg2 = new XElement(BaseNameSpace + "sp"){Value = sp};
            lastChild.Add(arg1);
            lastChild.Add(arg2);


            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.CheckServiceUser]}");

            var request = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            request.EnsureSuccessStatusCode();

            return true;
        }


        public void CloseWaybill(string su, string sp, int waybillId)
        {
            throw new NotImplementedException();
        }


        public void CloseWaybillTransporter()
        {
            throw new NotImplementedException();
        }

        public void CloseWaybillVd()
        {
            throw new NotImplementedException();
        }

        public void ConfirmWaybill()
        {
            throw new NotImplementedException();
        }


        public void DelWaybill()
        {
            throw new NotImplementedException();
        }

        public void DeleteBarCode()
        {
            throw new NotImplementedException();
        }

        public void DeleteCarNumbers()
        {
            throw new NotImplementedException();
        }


        public void DeleteWaybillTemplate()
        {
            throw new NotImplementedException();
        }

        public void GetAdjustedWaybill()
        {
            throw new NotImplementedException();
        }

        public void GetAdjustedWaybills()
        {
            throw new NotImplementedException();
        }

        public void GetAkcizCodes()
        {
            throw new NotImplementedException();
        }

        public void GetBarCodes()
        {
            throw new NotImplementedException();
        }

        public void GetBuyerWaybillGoodsList()
        {
            throw new NotImplementedException();
        }

        public void GetBuyersWaybills()
        {
            throw new NotImplementedException();
        }

        public void GetBuyersWaybillsEx()
        {
            throw new NotImplementedException();
        }

        public void GetCWaybills()
        {
            throw new NotImplementedException();
        }

        public void GetCarNumbers()
        {
            throw new NotImplementedException();
        }

        public void GetErrorCodes()
        {
            throw new NotImplementedException();
        }


        public void GetNameFromTin()
        {
            throw new NotImplementedException();
        }
    }
}
