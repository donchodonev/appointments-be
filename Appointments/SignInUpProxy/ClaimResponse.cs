using System.Text.Json.Serialization;

namespace SignInUpProxy
{
    public class ClaimResponse : ContinuationResponse
    {
        [JsonPropertyName("appRole")]
        public string AppRole { get; set; }
    }
}
