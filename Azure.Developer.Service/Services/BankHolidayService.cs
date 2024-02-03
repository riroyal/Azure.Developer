using CDW.Developer.Service.Api;
using Newtonsoft.Json;
using CDW.Developer.Service.Response;
using CDW.Developer.Service.Entities.DTO;
using CDW.Developer.Service.Repository;

namespace CDW.Developer.Service.Services
{
    public class BankHolidayService : IBankHolidayService
    {
        private readonly IApiService _apiService;
        private readonly IRequestRepository _requestRepository;

        public BankHolidayService(IApiService apiService, IRequestRepository requestRepository)
        {
            _apiService = apiService;
            _requestRepository = requestRepository;
        }

        public async Task<ServiceResponse<BankHoliday>> GetBankHolidaysAsync()
        {
            //Get data from bank holiday API
            var responseContent = await _apiService.GetBankHolidaysAsync();

            // Log to DB
            await _requestRepository.AddAsync(Guid.NewGuid().ToString(), responseContent, DateTime.UtcNow);

            var bankHolidays = JsonConvert.DeserializeObject<BankHoliday>(responseContent);

            return new ServiceResponse<BankHoliday>(bankHolidays);
        }
    }
}
