using System.Reflection;
using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ContinuationResponse
    {
        [JsonPropertyName("version")]
        public string Version => Assembly.GetEntryAssembly().GetName().Version.ToString();

        [JsonPropertyName("action")]
        public string Action => "Continue";
    }
}
