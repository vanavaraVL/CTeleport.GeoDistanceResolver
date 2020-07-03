using System;
using System.Collections.Generic;
using System.Text;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using CTeleport.GeoDistanceResolver.Test.Environments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTeleport.GeoDistanceResolver.Test
{
    [TestClass]
    public class GeoDistanceTest
    {
        private readonly TestEnvironment _testEnvironment;

        private const double _distanceKm = 635;
        private const double _distanceMl = 395;
        private const double _distanceM = 634990;

        public GeoDistanceTest()
        {
            _testEnvironment = TestEnvironment.GetInstance();
        }

        [TestMethod]
        public void FindDistance_Moscow_Petersburg_By_Default_Unit_Test()
        {
            // arrange
            var distanceResolver = _testEnvironment.Resolve<IGeoDistanceResolver>();

            var pointMoscow = new GeoPoint(37.620393, 55.753960);
            var pointPetersburg = new GeoPoint(30.315868, 59.939095);

            // act
            var result = distanceResolver.ResolveDistance(pointMoscow, pointPetersburg);

            // asserts
            Assert.AreEqual(_distanceM, Math.Round(result));
        }

        [TestMethod]
        public void FindDistance_Moscow_Petersburg_With_Units_Test()
        {
            // arrange
            var distanceResolver = _testEnvironment.Resolve<IGeoDistanceResolver>();

            var pointMoscow = new GeoPoint(37.620393, 55.753960);
            var pointPetersburg = new GeoPoint(30.315868, 59.939095);

            // act
            var resultKilometers = distanceResolver.ResolveDistance(pointMoscow, pointPetersburg, EMeasureUnit.Kilometers);
            var resultMiles = distanceResolver.ResolveDistance(pointMoscow, pointPetersburg, EMeasureUnit.Miles);

            // asserts
            Assert.AreEqual(_distanceKm, Math.Round(resultKilometers));
            Assert.AreEqual(_distanceMl, Math.Round(resultMiles));
        }
    }
}
