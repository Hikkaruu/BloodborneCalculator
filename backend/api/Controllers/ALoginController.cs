using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Method = RestSharp.Method;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("🛡️ Authorization")]
    public class ALoginController : ControllerBase
    {
        private static string clientId = Environment.GetEnvironmentVariable("CLIENT_ID")!;
        private static string audience = Environment.GetEnvironmentVariable("AUDIENCE")!;
        private static string authority = Environment.GetEnvironmentVariable("AUTHORITY")!;
        private static string scope = "openid email profile";
        private static string getDeviceCodeUrl = $"client_id={clientId}&scope={scope}&audience={audience}";

        [HttpPost("GetDeviceCode")]
        public async Task<IActionResult> GetDeviceCode()
        {
            var client = new RestClient($"{authority}/oauth/device/code");
            var request = new RestRequest
            {
                Method = Method.Post
            };
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter($"application/x-www-form-urlencoded", getDeviceCodeUrl, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            return Ok(response.Content);
        }

        [HttpPost("GetAccessToken")]
        [SwaggerRequestExample(typeof(DeviceCodeRequest), typeof(DeviceCodeExample))]
        public async Task<IActionResult> GetAccessToken(JObject requestBody)
        {
            string deviceCode = (string)requestBody["DeviceCode"]!;
            string getAccessTokenUrl = $"grant_type=urn:ietf:params:oauth:grant-type:device_code&device_code={deviceCode}&client_id={clientId}";
            Console.WriteLine($"getAccessTokenUrl: {getAccessTokenUrl}");

            var client = new RestClient($"{authority}/oauth/token");
            var request = new RestRequest
            {
                Method = Method.Post
            };
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter($"application/x-www-form-urlencoded", getAccessTokenUrl, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                JObject responseData = JObject.Parse(response.Content!);
                string accessToken = (string)responseData["access_token"]!;
                return Ok(new { AccessToken = accessToken });
            }
            else
            {
                JObject responseData = JObject.Parse(response.Content!);
                string error = (string)responseData["error"]!;
                return BadRequest(new { Error = error });
            }
        }
    }
}
