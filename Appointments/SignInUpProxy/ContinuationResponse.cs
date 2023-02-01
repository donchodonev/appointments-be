using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ContinuationResponse
    {
        [JsonPropertyName("action")]
        public string Action => "Continue";
    }
}
