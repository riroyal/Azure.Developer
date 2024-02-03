using CDW.Developer.Service.Entities.DTO;
using CDW.Developer.Service.Response;
using CDW.Developer.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CDW.Developer.FunctionApp.Test.FunctionApp
{
    [TestFixture]
    public class BankHolidayFunctiontests
    {
        private Mock<IBankHolidayService> _mockBankHolidayService;
        
        [SetUp]
        public void SetUp()
        {
            _mockBankHolidayService = new Mock<IBankHolidayService>();
        }

        [Test]
        public async Task GetBankHolidays_NoError_ReturnsAllBankHolidays()
        {
            // Arrange                        
            var bankHoliday = new BankHoliday { };
            _mockBankHolidayService.Setup(x =>
                    x.GetBankHolidaysAsync())
                .ReturnsAsync(new ServiceResponse<BankHoliday>(bankHoliday));

            var function = new Function(_mockBankHolidayService.Object);

            // Act
            var response = await function.GetBankHolidays(null);

            // Assert
            Assert.That(response, Is.TypeOf<OkObjectResult>());

            var responseContent = (response as OkObjectResult).Value;

            Assert.That(responseContent, Is.Not.Null);
            Assert.That(responseContent, Is.SameAs(bankHoliday));
            _mockBankHolidayService.Verify(x => x.GetBankHolidaysAsync(), Times.Once);
        }
    }
}
