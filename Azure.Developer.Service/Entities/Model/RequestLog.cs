namespace CDW.Developer.Service.Entities.Model
{
    public class RequestLog
    {
        public required string Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public required string Data { get; init; }
    }
}
