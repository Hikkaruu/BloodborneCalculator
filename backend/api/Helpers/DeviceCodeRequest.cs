using Newtonsoft.Json;

namespace api.Helpers
{
    public class DeviceCodeRequest
    {
        [JsonProperty("DeviceCode")]
        public string DeviceCode { get; set; } = "";
    }
}
