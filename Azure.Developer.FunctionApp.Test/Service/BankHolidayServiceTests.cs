using CDW.Developer.Service.Api;
using CDW.Developer.Service.Repository;
using CDW.Developer.Service.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CDW.Developer.FunctionApp.Test.Service
{
    [TestFixture]
    public class BankHolidayServiceTests
    {
        private IRequestRepository _mockRequestRepository;
        private IApiService _mockApiService;
        private string _esriEltracsResponseJson;

        //If I had time I would add more tests, I would add tests for repository, api service using httpMock

        [OneTimeSetUp]
        public void SetUp()
        {
            var repoMockLogger = new Mock<ILogger<RequestRepository>>();
            var repoApiMockLogger = new Mock<ILogger<ApiService>>();

            var dbContext = Utils.GetInMemoryDbContext();
            
            _esriEltracsResponseJson = Utils.GetJsonFromTestDataFile();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var eltracsResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(_esriEltracsResponseJson)
            };

            mockHttpMessageHandler
                .Protected()
                .Setup<Task>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(eltracsResponse));

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };

            _mockRequestRepository = new RequestRepository(repoMockLogger.Object, dbContext);
            _mockApiService = new ApiService(httpClient, repoApiMockLogger.Object);
        }

        [Test]
        public async Task GetAllBankHolidaysAsync_HolidaysData_ReturnsObjectNotNull()
        {
            //Arrange
            Environment.SetEnvironmentVariable("BaseUrl", "http://www.gov.uk/");
            var bankHolidayService = new BankHolidayService(_mockApiService, _mockRequestRepository);

            ////Act
            var repsonse = await bankHolidayService.GetBankHolidaysAsync();

            //Assert
            Assert.That(repsonse, Is.Not.Null);
            Assert.That(repsonse.HasError, Is.False);
        }
    }
}
