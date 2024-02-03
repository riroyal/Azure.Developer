using CDW.Developer.Service.DbContext;
using CDW.Developer.Service.Entities.Model;
using Microsoft.Extensions.Logging;

namespace CDW.Developer.Service.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ILogger<RequestRepository> _logger;
        private readonly AppDbContext _dbContext;

        public RequestRepository(ILogger<RequestRepository> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task AddAsync(string id, string content, DateTime currentDateTime)
        {
            _logger.LogInformation($"Logged to database: ${id}");

            var requestLog = new RequestLog()
            {
                Data = content,
                Id = id,
                CreatedAt = currentDateTime
            };

            await _dbContext.Requests.AddAsync(requestLog);

            await _dbContext.SaveChangesAsync();
        }
    }
}
