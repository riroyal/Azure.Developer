using CDW.Developer.Service.Entities.DTO;
using CDW.Developer.Service.Response;

namespace CDW.Developer.Service.Services
{
    public interface IBankHolidayService
    {
        Task<ServiceResponse<BankHoliday>> GetBankHolidaysAsync();
    }
}