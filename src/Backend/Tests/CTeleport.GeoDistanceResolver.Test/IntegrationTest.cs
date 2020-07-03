using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CTeleport.GeoDistanceResolver.Test.Environments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTeleport.GeoDistanceResolver.Test
{
    [TestClass]
    public class IntegrationTest
    {
        private readonly IntegrationEnvironment _integrationEnvironment;

        public IntegrationTest()
        {
            _integrationEnvironment = new IntegrationEnvironment();

            _integrationEnvironment.Initialize();
        }

        [TestMethod]
        public async Task GetDistance_Should_200HTTP()
        {
            // arrange
            var uri = $"api/GeoCoordinateResolver?airportFrom=mow&airportTo=led";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            // act
            var responseMessage = await _integrationEnvironment.Client.SendAsync(requestMessage);
            var responseBody = await responseMessage.Content.ReadAsStringAsync();

            // assert
            Assert.AreEqual(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
