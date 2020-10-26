using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using RSServices.RequestParams;
using RSServices.ResponseParams;
using RSServices.Responses;

namespace RSServices
{

    public class WaybillService
    {
        private const string ContentType = "";

        public static readonly XNamespace BaseNameSpace = "http://tempuri.org/";

        private string _su;

        private string _sp;

        private HttpClient _client;

        private readonly Dictionary<RequestNames, string> _requests = new Dictionary<RequestNames, string>()
        {
            {RequestNames.CheckServiceUser, "chek_service_user"},
            {RequestNames.CreateServiceUser, "create_service_user"},
            {RequestNames.WhatIsMyIp, "what_is_my_ip"},
            {RequestNames.CloseWaybill, "close_waybill"},
            {RequestNames.CloseWaybillTransporter, "close_waybill_transporter"},
            {RequestNames.CloseWaybillVd, "close_waybill_vd"},
            {RequestNames.ConfirmWaybill, "confirm_waybill"},
            {RequestNames.DelWaybill, "del_waybill"},
            {RequestNames.DeleteBarCode, "delete_bar_code"},
            {RequestNames.DeleteCarNumbers, "delete_car_numbers"},
            {RequestNames.DeleteWaybillTemplate, "delete_waybill_tamplate"},
            {RequestNames.GetAdjustedWaybill, "get_adjusted_waybill"},
            {RequestNames.GetAdjustedWaybills, "get_adjusted_waybills"},
            {RequestNames.GetAkcizCodes, "get_akciz_codes"},
            {RequestNames.GetBarCodes, "get_bar_codes"},
            {RequestNames.GetBuyerWaybillGoodsList, "get_buyer_waybilll_goods_list"},
            {RequestNames.GetBuyersWaybills, "get_buyer_waybills"},
            {RequestNames.GetBuyersWaybillsEx, "get_buyer_waybills_ex"},
            {RequestNames.GetCWaybill, "get_c_waybill"},
            {RequestNames.GetCarNumbers, "get_car_numbers"},
            {RequestNames.GetErrorCodes, "get_error_codes"},
            {RequestNames.GetNameFromTin, "get_name_from_tin"},
            {RequestNames.GetPayerTypeFromUnId, "get_payer_type_from_un_id"},
            {RequestNames.GetPrintPdf, "get_print_pdf"},
            {RequestNames.GetServerTime, "get_server_time"},
            {RequestNames.GetServiceUsers, "get_service_users"},
            {RequestNames.GetTinFromUnId, "get_tin_from_un_id"},
            {RequestNames.GetTransTypes, "get_trans_types"},
            {RequestNames.GetTransporterWaybills, "get_transporter_waybills"},
            {RequestNames.GetWaybill, "get_waybill"},
            {RequestNames.GetWaybillByNumber, "get_waybill_by_number"},
            {RequestNames.GetWaybillGoodsList, "get_waybill_goods_list"},
            {RequestNames.GetWaybillTemplate, "get_waybill_tamplate" },
            {RequestNames.GetWaybillTemplates, "get_waybill_tamplates" },
            {RequestNames.GetWaybillTypes, "get_waybill_types" },
            {RequestNames.GetWaybillUnits, "get_waybill_units" },
            {RequestNames.GetWaybills, "get_waybills" },
            {RequestNames.GetWaybillsEx, "get_waybills_ex" },
            {RequestNames.GetWoodTypes, "get_wood_types" },
            {RequestNames.IsVatPayer, "is_vat_payer" },
            {RequestNames.IsVatPayerTin, "is_vat_payer_tin" },
            {RequestNames.RefWaybill, "ref_waybill" },
            {RequestNames.RefWaybillVd, "ref_waybill_vd" },
            {RequestNames.RejectWaybill, "reject_waybill" },
            {RequestNames.SaveBarCode, "save_bar_code" },
            {RequestNames.SaveCarNumbers, "save_car_numbers" },
            {RequestNames.SaveInvoice, "save_invoice" },
            {RequestNames.SaveWaybillTamplate, "save_waybill_tamplate" },
            {RequestNames.SaveWaybillTransporter, "save_waybill_transporter" },
            {RequestNames.SendWaybillVd, "send_waybil_vd" },
            {RequestNames.SendWaybill, "send_waybill" },
            {RequestNames.SendWaybillTransporter, "send_waybill_transporter" },
            {RequestNames.UpdateServiceUser, "update_service_user" }

        };

        enum RequestNames
        {
            CheckServiceUser, CreateServiceUser, WhatIsMyIp, CloseWaybill, CloseWaybillTransporter, CloseWaybillVd, ConfirmWaybill,
            DelWaybill, DeleteBarCode, DeleteCarNumbers, DeleteWaybillTemplate, GetAdjustedWaybill, GetAdjustedWaybills, GetAkcizCodes,
            GetBarCodes, GetBuyerWaybillGoodsList, GetBuyersWaybills, GetBuyersWaybillsEx, GetCWaybill, GetCarNumbers, GetErrorCodes,
            GetNameFromTin, GetPayerTypeFromUnId, GetPrintPdf, GetServerTime, GetServiceUsers, GetTinFromUnId, GetTransTypes,
            GetTransporterWaybills, GetWaybill, GetWaybillByNumber, GetWaybillGoodsList, GetWaybillTemplate, GetWaybillTemplates,
            GetWaybillTypes, GetWaybillUnits, GetWaybills, GetWaybillsEx, GetWoodTypes, IsVatPayer, IsVatPayerTin, RefWaybill,
            RefWaybillVd, RejectWaybill, SaveBarCode, SaveCarNumbers, SaveInvoice, SaveWaybill, SaveWaybillTamplate, SaveWaybillTransporter,
            SendWaybillVd, SendWaybill, SendWaybillTransporter, UpdateServiceUser
        }

        public WaybillService(string su, string sp)
        {
            _su = su;
            _sp = sp;
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://services.rs.ge/WayBillService/WayBillService.asmx")
            };
        }




        /// <summary>
        /// checks if given service user is valid
        /// </summary>
        /// 
        /// <returns>true if su and sp was valid, false otherwise</returns>
        public async Task<CheckServiceUserResponse> CheckServiceUserAsync()
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.CheckServiceUser]);

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.CheckServiceUser]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<CheckServiceUserResponse>));

            var responseBody = (ResponseBody<CheckServiceUserResponse>)serializer.Deserialize(content);

            return responseBody.Body;
        }


        public async Task<CloseWaybillResponse> CloseWaybillAsync(int waybillId)
        {
            var document = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.CloseWaybill]);
            var lastChild = document.Value;

            lastChild.Add(new XElement("waybill_id") { Value = waybillId.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.CloseWaybill]}");
            message.Content = Helper.GetXmlBody(document.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<CloseWaybillResponse>));

            var respBody = (ResponseBody<CloseWaybillResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        //
        public async Task<string> CloseWaybillTransporterAsync(CloseWaybillTransporterParams closeWTParams)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.CloseWaybillTransporter]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "waybill_id") { Value = closeWTParams.WaybillId.ToString() });

            if (!string.IsNullOrEmpty(closeWTParams.ReceptionInfo))
                lastChild.Add(new XElement(BaseNameSpace + "reception_info") { Value = closeWTParams.ReceptionInfo });

            if (!string.IsNullOrEmpty(closeWTParams.ReceiverInfo))
                lastChild.Add(new XElement("receiver_info") { Value = closeWTParams.ReceiverInfo });

            if (closeWTParams.deliveryDate != null)
                lastChild.Add(new XElement("delivery_date") { Value = closeWTParams.deliveryDate.ToString() });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.CloseWaybillTransporter]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<CloseWaybillVdResponse> CloseWaybillVdAsync(int waybillId, DateTime? deliveryDate)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.CloseWaybillVd]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "waybill_id") { Value = waybillId.ToString() });

            if(deliveryDate != null)
                lastChild.Add(new XElement(BaseNameSpace + "delivery_date") { Value = deliveryDate.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.CloseWaybillVd]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<CloseWaybillVdResponse>));

            var respBody = (ResponseBody<CloseWaybillVdResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<ConfirmWaybillResponse> ConfirmWaybillAsync(int waybillId)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.ConfirmWaybill]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "waybill_id") { Value = waybillId.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.ConfirmWaybill]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<ConfirmWaybillResponse>));

            var respBody = (ResponseBody<ConfirmWaybillResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<CreateServiceUserResponse> CreateServiceUserAsync(CreateServiceUserParams CreateSUParams)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.CreateServiceUser]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "user_name") { Value = CreateSUParams.Username });
            lastChild.Add(new XElement(BaseNameSpace + "user_password") { Value = CreateSUParams.Password });
            lastChild.Add(new XElement(BaseNameSpace + "ip") { Value = CreateSUParams.Ip });
            if (!string.IsNullOrEmpty(CreateSUParams.Name))
                lastChild.Add(new XElement(BaseNameSpace + "name") { Value = CreateSUParams.Name });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.CreateServiceUser]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;


            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var content = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<CreateServiceUserResponse>));
            var respBody = (ResponseBody<CreateServiceUserResponse>)serializer.Deserialize(content);

            return respBody.Body;
        }


        public async Task<DelWaybillResponse> DelWaybillAsync(int waybillId)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.DelWaybill]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "waybill_id") { Value = waybillId.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.DelWaybill]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<DelWaybillResponse>));

            var respBody = (ResponseBody<DelWaybillResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<DeleteBarCodeResponse> DeleteBarCodeAsync(string barCode)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.DeleteBarCode]);
            var lastChild = pair.Value;

            if (!string.IsNullOrEmpty(barCode))
                lastChild.Add(new XElement(BaseNameSpace + "bar_code") { Value = barCode }); 
            

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.DeleteBarCode]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<DeleteBarCodeResponse>));

            var respBody = (ResponseBody<DeleteBarCodeResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<DeleteCarNumbersResponse> DeleteCarNumbersAsync(string carNumber)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.DeleteCarNumbers]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "car_number") { Value = carNumber });


            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.DeleteCarNumbers]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<DeleteCarNumbersResponse>));

            var respBody = (ResponseBody<DeleteCarNumbersResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }


        public async Task<DeleteWaybillTemplateResponse> DeleteWaybillTemplateAsync(int id)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.DeleteWaybillTemplate]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "id") { Value = id.ToString() });


            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.DeleteWaybillTemplate]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<DeleteWaybillTemplateResponse>));

            var respBody = (ResponseBody<DeleteWaybillTemplateResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<string> GetAdjustedWaybillAsync(int id)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetAdjustedWaybill]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "id") { Value = id.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetAdjustedWaybills]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            // _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetAdjustedWaybills]}");

            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetAdjustedWaybillsAsync(int waybillId)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetAdjustedWaybills]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "waybill_id") { Value = waybillId.ToString() });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetAdjustedWaybills]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<List<GetAkcizCodesResultElem>> GetAkcizCodesAsync()
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetAkcizCodes]);

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetAkcizCodes]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;


            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<GetAkcizCodesResponse>));
            var respBody = (ResponseBody<GetAkcizCodesResponse>)serializer.Deserialize(content);

            var result = respBody.Body.ResponseBody.Result.ListParent.CodesList;

            return result;
        }

        public async Task<string> GetBarCodesAsync(string barCode)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetBarCodes]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement(BaseNameSpace + "bar_code") { Value = barCode });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetBarCodes]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetBuyerWaybillGoodsListAsync(BuyerWaybillParams waybillParams)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetBuyerWaybillGoodsList]);
            var lastChild = pair.Value;

            if (waybillParams != null)
                lastChild.Add(waybillParams);


            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetBuyerWaybillGoodsList]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;

            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<List<GetBuyersWaybillsResultElem>> GetBuyersWaybillsAsync(BuyerWaybillParams waybillParams)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetBuyersWaybills]);
            var lastChild = pair.Value;

            lastChild.Add(waybillParams);

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetBuyersWaybills]}");
            message.Content = Helper.GetXmlBody(pair.Key);
            message.Method = HttpMethod.Post;


            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<GetBuyersWaybillsResponse>));

            var respBody = (ResponseBody<GetBuyersWaybillsResponse>)serializer.Deserialize(content);

            return respBody.Body.ResponseBody.Result.ListParent.WaybillList;
        }

        public async Task<string> GetBuyersWaybillsExAsync(BuyerWaybillParams waybillParams, int isConfirmed)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetBuyersWaybillsEx]);
            var lastChild = pair.Value;

            lastChild.Add(waybillParams);
            lastChild.Add(new XElement("is_confirmed") { Value = isConfirmed.ToString() });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetBuyersWaybillsEx]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        //
        public async Task<string> GetCWaybillAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetCarNumbersAsync()
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetCarNumbers]);

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetCarNumbers]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetErrorCodesAsync()
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetErrorCodes]);

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetErrorCodes]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }


        public async Task<string> GetNameFromTinAsync(string tin)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetNameFromTin]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement("tin") { Value = tin });


            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetNameFromTin]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }


        public async Task<string> GetPayerTypeFromUnIdAsync(int unId)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetPayerTypeFromUnId]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement("un_id") { Value = unId.ToString() });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetPayerTypeFromUnId]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetPrintPdfAsync(int waybillId)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetPrintPdf]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement("waybill_id") { Value = waybillId.ToString() });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetPrintPdf]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        //
        public async Task<string> GetServerTimeAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all created service users created on given account 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>List of elements created on this account</returns>
        public async Task<List<GetServiceUsersResultElem>> GetServiceUsersAsync(string userName, string password)
        {
            var document = Helper.GetServiceUsersXDocument(userName, password, _requests[RequestNames.GetServiceUsers]);

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetServiceUsers]}");
            message.Content = Helper.GetXmlBody(document);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<GetServiceUsersResponse>));

            var respBody = (ResponseBody<GetServiceUsersResponse>)serializer.Deserialize(response);

            var result = respBody.Body.ResponseBody.Result.ListParent.UsersList;

            return result;
        }

        public async Task<string> GetTinFromUnIdAsync(int unId)
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetTinFromUnId]);
            var lastChild = pair.Value;

            lastChild.Add(new XElement("un_id") { Value = unId.ToString() });

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetTinFromUnId]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetTransTypesAsync()
        {
            var pair = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.GetTransTypes]);

            _client.DefaultRequestHeaders.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.GetTransTypes]}");

            var response = await _client.PostAsync(_client.BaseAddress, Helper.GetXmlBody(pair.Key));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        //
        public async Task<string> GetTransporterWaybillsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillByNumberAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillGoodsListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillTemplateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillTemplatesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillTypesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillUnitsAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<string> GetWaybillsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWaybillsExAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetWoodTypesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IsVatPayerResponse> IsVatPayerAsync(int? unId)
        {
            var document = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.IsVatPayer]);
            var lastChild = document.Value;

            if (unId != null)
                lastChild.Add(new XElement("un_id") { Value = unId.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.IsVatPayer]}");
            message.Content = Helper.GetXmlBody(document.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<IsVatPayerResponse>));

            var respBody = (ResponseBody<IsVatPayerResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<IsVatPayerTinResponse> IsVatPayerTinAsync(string tin)
        {
            var document = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.IsVatPayerTin]);
            var lastChild = document.Value;

            if (!string.IsNullOrEmpty(tin))
                lastChild.Add(new XElement("tin") { Value = tin });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.IsVatPayerTin]}");
            message.Content = Helper.GetXmlBody(document.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<IsVatPayerTinResponse>));

            var respBody = (ResponseBody<IsVatPayerTinResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<RefWaybillResponse> RefWaybillAsync(int waybillId)
        {
            var document = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.RefWaybill]);
            var lastChild = document.Value;

            lastChild.Add(new XElement("waybill_id") { Value = waybillId.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.RefWaybill]}");
            message.Content = Helper.GetXmlBody(document.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<RefWaybillResponse>));

            var respBody = (ResponseBody<RefWaybillResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<RefWaybillVdResponse> RefWaybillVdAsync(int waybillId, string comment)
        {
            var document = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.RefWaybillVd]);
            var lastChild = document.Value;

            lastChild.Add(new XElement("waybill_id") { Value = waybillId.ToString() });

            if (!string.IsNullOrEmpty(comment))
                lastChild.Add(new XElement("comment") { Value = comment });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.RefWaybillVd]}");
            message.Content = Helper.GetXmlBody(document.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<RefWaybillVdResponse>));

            var respBody = (ResponseBody<RefWaybillVdResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<RejectWaybillResponse> RejectWaybillAsync(int waybillId)
        {
            var document = Helper.GetNewDocument(_su, _sp, _requests[RequestNames.RejectWaybill]);
            var lastChild = document.Value;

            lastChild.Add(new XElement("waybill_id") { Value = waybillId.ToString() });

            var message = new HttpRequestMessage();
            message.Headers.Add("SOAPAction", $"{BaseNameSpace}{_requests[RequestNames.RejectWaybill]}");
            message.Content = Helper.GetXmlBody(document.Key);
            message.Method = HttpMethod.Post;

            var request = await _client.SendAsync(message);
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ResponseBody<RejectWaybillResponse>));

            var respBody = (ResponseBody<RejectWaybillResponse>)serializer.Deserialize(response);

            var result = respBody.Body;

            return result;
        }

        public async Task<string> SaveBarCodeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveCarNumbersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveInvoiceAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveWaybillAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveWaybillTamplateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveWaybillTransporterAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendWaybillVdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendWaybillAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendWaybillTransporterAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateServiceUserAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<string> WhatIsMyIpAsync()
        {
            throw new NotImplementedException();
        }
    }
}
