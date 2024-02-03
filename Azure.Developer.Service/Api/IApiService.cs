
namespace CDW.Developer.Service.Api
{
    public interface IApiService
    {
        Task<string?> GetBankHolidaysAsync();
    }
}