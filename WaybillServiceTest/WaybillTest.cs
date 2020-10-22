using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSServices;
using RSServices.RequestParams;
using RSServices.ResponseParams;

namespace WaybillServiceTest
{
    [TestClass]
    public class WaybillTest
    {
        
       
        WaybillService _service = new WaybillService("", "");


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
            await _service.GetServiceUsersAsync("tbilisi", "123456");
        }

    }
}
