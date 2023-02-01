using System.Reflection;
using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ContinuationResponse
    {
        [JsonPropertyName("version")]
        protected string Version => Assembly.GetEntryAssembly().GetName().Version.ToString();

        [JsonPropertyName("action")]
        protected string Action => "Continue";
    }
}
