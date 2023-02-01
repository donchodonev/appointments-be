using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SignInUpProxy
{
    public class ClaimResponse : ContinuationResponse
    {
        [JsonPropertyName("appRole")]
        public string AppRole { get; set; }
    }
}
