using CTeleport.GeoDistanceResolver.Core.GeoGateway.Data;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Implementation;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using CTeleport.GeoDistanceResolver.Test.Environments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTeleport.GeoDistanceResolver.Test
{
    [TestClass]
    public class GatewayTest
    {
        private readonly TestEnvironment _testEnvironment;

        public GatewayTest()
        {
            _testEnvironment = TestEnvironment.GetInstance();
        }

        [TestMethod]
        public void ConnectAndGetDataTest()
        {
            // arrange
            var gatewayService = _testEnvironment.Resolve<IGatewayService>();

            // act
            var result = gatewayService.GetAirportData("AMS");

            // asserts
            Assert.IsNotNull(result);
            Assert.AreEqual("AMS", result.CityIata);
        }
    }
}
