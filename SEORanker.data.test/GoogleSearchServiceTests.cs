using Microsoft.Extensions.Configuration;
using Moq;
using RichardSzalay.MockHttp;
using SEORanker.data.Repositories;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SEORanker.data.test
{
    public class GoogleSearchServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfig;
        private const string Host = "http://searchengine.com";

        public GoogleSearchServiceTests()
        {
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "Host")]).Returns(Host);

            _mockConfig = new Mock<IConfiguration>();
            _mockConfig.Setup(a => a.GetSection(It.Is<string>(s => s == "Search"))).Returns(mockConfSection.Object);
        }

        [Theory]
        [InlineData("<!DOCTYPE html><html lang=\"en-AU\" ></html>")]
        [InlineData("<!DOCTYPE html><html lang=\"en-AU\" ><head></head><body><div>These are some search results</div></body></html>")]
        public async void GetSearchContent_ReturnsContent(string content)
        {
            var mockHttp = new MockHttpMessageHandler();
            var search = "anything here";
            mockHttp.When($"{Host}/search?q={search}&num=100").Respond("application/json", content);

            var httpClient = new HttpClient(mockHttp);
            var service = new GoogleSearchService(_mockConfig.Object, httpClient);

            var result = await service.GetSearchContent(search);

            Assert.NotNull(result);
            Assert.Equal(result, content);
        }

        [Fact]
        public async void GetSearchContent_ReturnsNull_WhenNotFound()
        {
            var mockHttp = new MockHttpMessageHandler();
            var search = "anything here";
            mockHttp.When($"{Host}/search?q={search}&num=100").Respond(HttpStatusCode.NotFound);

            var httpClient = new HttpClient(mockHttp);
            var service = new GoogleSearchService(_mockConfig.Object, httpClient);

            var result = await service.GetSearchContent(search);

            Assert.Null(result);
        }
    }
}
