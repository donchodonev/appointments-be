using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ClaimResponse : ContinuationResponse
    {
        [JsonPropertyName("extension_appRole")]
        public string Extension_AppRole { get; set; }
    }
}
