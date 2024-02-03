using Newtonsoft.Json;

namespace CDW.Developer.Service.Entities.DTO
{
    public partial class EnglandAndWales
    {
        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }
}
