using CDW.Developer.Service.Entities.Model;

namespace CDW.Developer.Service.Repository
{
    public interface IRequestRepository
    {
        Task AddAsync(string id, string content, DateTime currentDateTime);
    }
}