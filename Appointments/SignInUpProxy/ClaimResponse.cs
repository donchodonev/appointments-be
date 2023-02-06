using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ClaimResponse : ContinuationResponse
    {
        [JsonPropertyName("extension_AppRole")]
        public string Extension_AppRole { get; set; }
    }
}
