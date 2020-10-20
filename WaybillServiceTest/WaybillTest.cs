using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSServices;

namespace WaybillServiceTest
{
    [TestClass]
    public class WaybillTest
    {
        
        WaybillService _service = new WaybillService("","");


        [TestMethod]
        public void CheckServiceUserTest()
        {
            _service.CheckServiceUserAsync().Wait();
        }
    }
}
