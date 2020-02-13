using Moq;
using SEORanker.data.Repositories;
using SEORanker.domain.Managers;
using System;
using Xunit;

namespace SEORanker.domain.test
{
    public class SeoRankerManagerTests
    {
        private readonly Mock<ISearchService> _mockService;
        private SeoRankManager _manager;

        public SeoRankerManagerTests()
        {
            _mockService = new Mock<ISearchService>();
            _manager = new SeoRankManager( _mockService.Object);
        }

        [Fact]
        public async void GetSearchContent_ReturnsString_WhenServiceReturnsContent()
        {
            _mockService.Setup(x => x.GetSearchContent(It.IsAny<string>())).ReturnsAsync("any string");

            var result = await _manager.GetSearchContent("search stuff");

            Assert.IsType<string>(result);
        }

        [Fact]
        public async void GetSearchContent_ReturnsNull_WhenNullReturnedFromService()
        {
            string content = null;
            _mockService.Setup(x => x.GetSearchContent(It.IsAny<string>())).ReturnsAsync(content);

            var result = await _manager.GetSearchContent("random kjsahdi");

            Assert.Null(result);
        }
    }
}
