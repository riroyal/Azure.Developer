using Newtonsoft.Json;

namespace CDW.Developer.Service.Entities.DTO
{
    public partial class Event
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("bunting")]
        public bool Bunting { get; set; }
    }
}
