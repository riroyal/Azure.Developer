using Newtonsoft.Json;

namespace CDW.Developer.Service.Entities.DTO
{
    public partial class BankHoliday
    {
        [JsonProperty("england-and-wales")]
        public EnglandAndWales EnglandAndWales { get; set; }

        [JsonProperty("scotland")]
        public EnglandAndWales Scotland { get; set; }

        [JsonProperty("northern-ireland")]
        public EnglandAndWales NorthernIreland { get; set; }
    }
}
