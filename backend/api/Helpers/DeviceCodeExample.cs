using Swashbuckle.AspNetCore.Filters;

namespace api.Helpers
{
    public class DeviceCodeExample : IExamplesProvider<DeviceCodeRequest>
    {
        public DeviceCodeRequest GetExamples()
        {
            return new DeviceCodeRequest { DeviceCode = "" };
        }
    }
}
