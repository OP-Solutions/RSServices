using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSServices;
using RSServices.RequestParams;
using RSServices.ResponseParams;
using RSServices.Responses;

namespace WaybillServiceTest
{
    [TestClass]
    public class WaybillTest
    {

        //Robotaaa:206322102
        //Robotaaa
        //Robota121
        WaybillService _service = new WaybillService("Robotaaa:206322102", "Robota121");


        [TestMethod]
        public async Task CheckServiceUserTest()
        {
            var response = await _service.CheckServiceUserAsync();
        }

        [TestMethod]
        public async Task CreateServiceUserTest()
        {
            var myParams = new CreateServiceUserParams();

            var response = await _service.CreateServiceUserAsync(myParams);
        }

        [TestMethod]
        public async Task GetServiceUsersTest()
        {
            var response = await _service.GetServiceUsersAsync("tbilisi", "123456");
        }

        [TestMethod]
        public async Task GetAkcizCodesTest()
        {
            var response = await _service.GetAkcizCodesAsync();
        }


        [TestMethod]
        public async Task GetBuyersWaybillsTest()
        {
            var response = await _service.GetBuyersWaybillsAsync(new BuyerWaybillParams());

        }


        [TestMethod]
        public async Task GetBuyerGoodsListTest()
        {
            var response = await _service.GetBuyerWaybillGoodsListAsync(null);
        }


        [TestMethod]
        public void SerializeTest()
        {
            #region GetServiceUsersTest
            //var elem1 = new GetServiceUsersResultElem()
            //{
            //    Name = "xatake",
            //    Ip = "a2",
            //    UnId = 123,
            //    Id = 12,
            //    UserName = "kakashi"
            //};

            //var elem2 = new GetServiceUsersResultElem()
            //{
            //    Name = "atake",
            //    Ip = "a23",
            //    UnId = 123312312,
            //    Id = 123123,
            //    UserName = "xaxashi"
            //};

            //var myList = new GetServiceUsersResultList();
            //myList.UsersList = new List<GetServiceUsersResultElem>()
            //{
            //    elem1, elem2
            //};

            //var myChudo = new GetServiceUsersResult();
            //myChudo.ListParent = myList;

            //var rarara = new GetServiceUsersResponseBody { Result = myChudo };

            //var ririri = new GetServiceUsersResponse { ResponseBody = rarara };

            //var myParams = new ResponseBody<GetServiceUsersResponse> { Body = ririri };


            //var serializer = new XmlSerializer(typeof(ResponseBody<GetServiceUsersResponse>));

            //using (var stream = new FileStream("C:\\Users\\vmela\\Desktop\\papachana.txt", FileMode.OpenOrCreate))
            //{
            //    serializer.Serialize(stream, myParams);
            //}
            #endregion

            #region GetAkcizCodeTest
            //var code1 = new GetAkcizCodesResultElem()
            //{
            //    Id = 123,
            //    AkcizCode = "123",
            //    AkcizRate = 2.3,
            //    Measurement = "chudo",
            //    Title = "budo",
            //    EndDate = DateTime.Now,
            //    StartDate = DateTime.MinValue
            //};

            //var code2 = new GetAkcizCodesResultElem()
            //{
            //    Id = 1234,
            //    AkcizCode = "123123",
            //    AkcizRate = 2.33,
            //    Measurement = "cudo",
            //    Title = "brudo",
            //    StartDate = DateTime.MaxValue
            //};

            //var myCodeList = new GetAkcizCodesResultList();
            //myCodeList.CodesList = new List<GetAkcizCodesResultElem>()
            //{
            //    code1, code2
            //};

            //var myCodeChudo = new GetAkcizCodesResult();
            //myCodeChudo.ListParent = myCodeList;

            //var rararaCode = new GetAkcizCodesResponseBody() { Result = myCodeChudo };

            //var riririCode = new GetAkcizCodesResponse() { ResponseBody = rararaCode };

            //var myCodeParams = new ResponseBody<GetAkcizCodesResponse> { Body = riririCode };

            //var codeSerializer = new XmlSerializer(typeof(ResponseBody<GetAkcizCodesResponse>));

            //using (var stream = new FileStream("C:\\Users\\vmela\\Desktop\\papachana.txt", FileMode.OpenOrCreate))
            //{
            //    codeSerializer.Serialize(stream, myCodeParams);
            //} 
            #endregion
        }

    }
}
