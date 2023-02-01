using System.Reflection;
using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ClaimResponse : ContinuationResponse
    {
        [JsonPropertyName("version")]
        public string Version => Assembly.GetEntryAssembly().GetName().Version.ToString();

        [JsonPropertyName("appRole")]
        public string AppRole { get; set; }
    }
}
