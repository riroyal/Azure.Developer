using CDW.Developer.Service.Common;
using Microsoft.Extensions.Logging;

namespace CDW.Developer.Service.Api
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string?> GetBankHolidaysAsync()
        {
            try
            {
                var baseUrl = Environment.GetEnvironmentVariable(Constants.BaseUrl);
                var endPoint = "bank-holidays.json";

                _httpClient.BaseAddress = new Uri(baseUrl);

                var apiResponse = await _httpClient.GetAsync(endPoint);

                apiResponse.EnsureSuccessStatusCode();

                return await apiResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error occurred while reading BankHolidays api {ex.Message}");
                throw;
            }
        }
    }
}
