using System;
using CTeleport.GeoDistanceResolver.Application;
using CTeleport.GeoDistanceResolver.Data.Dto;
using CTeleport.GeoDistanceResolver.Test.Environments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTeleport.GeoDistanceResolver.Test
{
    [TestClass]
    public class GeoServiceTest
    {
        private readonly TestEnvironment _testEnvironment;

        public GeoServiceTest()
        {
            _testEnvironment = TestEnvironment.GetInstance();
        }

        [TestMethod]
        public void GetResultFromApplicationService_From_MOW_to_LED_Test()
        {
            // arrange
            var service = _testEnvironment.Resolve<GeoCoordinateService>();

            // act
            var result = service.FindDistanceBetweenAirports("MOW", "LED");
            var resultKm = service.FindDistanceBetweenAirports("MOW", "LED", EMeasureUnitDto.Kilometers);

            // asserts
            Assert.IsNotNull(result);

            Assert.AreEqual("MOW", result.FromAirport.AirportCode);
            Assert.AreEqual("LED", result.ToAirport.AirportCode);

            Assert.AreEqual(666333, Math.Round(result.Distance));
            Assert.AreEqual(668, Math.Round(resultKm.Distance));
        }
    }
}
