using Microsoft.AspNetCore.Mvc;
using Moq;
using SEORanker.domain.Managers;
using SEORanker.presentation.Controllers;
using SEORanker.presentation.RequestModels;
using Xunit;

namespace SEORanker.presentation.test
{
    public class SeoRankControllerTests
    {
        private readonly Mock<ISeoRankManager> _mockManager;
        private SeoRankController _controller;

        public SeoRankControllerTests()
        {
            _mockManager = new Mock<ISeoRankManager>();
            _controller = new SeoRankController(_mockManager.Object);
        }

        [Fact]
        public async void GetSearchContent_ReturnsOk_WhenManagerReturnsContent()
        {
            // Arrange
            _mockManager.Setup(x => x.GetSearchContent(It.IsAny<string>())).ReturnsAsync("any string");

            // Act
            var search = new SeoRankSearch { Search = "online title search" };
            IActionResult result = await _controller.GetSearchContent(search);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<string>(objectResult.Value);
        }

        [Theory]
        [InlineData("<!DOCTYPE html><html lang=\"en-AU\" ></html>")]
        public async void GetSearchContent_ReturnsCorrectString(string content)
        {
            // Arrange
            _mockManager.Setup(x => x.GetSearchContent(It.IsAny<string>())).ReturnsAsync(content);

            // Act
            var search = new SeoRankSearch { Search = "online title search" };
            IActionResult result = await _controller.GetSearchContent(search);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(objectResult.Value, content);
        }

        [Fact]
        public async void GetSearchContent_ReturnsNotFound_WhenNullResponse()
        {
            string content = null;
            _mockManager.Setup(x => x.GetSearchContent(It.IsAny<string>())).ReturnsAsync(content);


            var search = new SeoRankSearch { Search = "a very random dskahfisa search ndkosahfoaslg" };
            IActionResult result = await _controller.GetSearchContent(search);

            var objectResult = Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
