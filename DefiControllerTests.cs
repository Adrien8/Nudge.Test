using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Nudge.Tests
{
    public class DefiControllerTests
    : IClassFixture<WebApplicationFactory<Nudge.Startup>>
    {
        private readonly WebApplicationFactory<Nudge.Startup> _factory;

        public DefiControllerTests(WebApplicationFactory<Nudge.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Defi/Index")]
        [InlineData("/Defi/Delete")]
        [InlineData("/Defi/Edit")]
        [InlineData("/Defi/Create")]
        [InlineData("/Defi/Details")]

        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}