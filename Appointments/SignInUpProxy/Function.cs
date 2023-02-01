using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;

namespace SignInUpProxy
{
    public static class Function
    {
        [FunctionName("AppendRoleClaim")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            var claimResponse = new ClaimResponse { AppRole = "USER"};

            using (var reader = new StreamReader(req.Body))
            {
                var requestBody = await reader.ReadToEndAsync();

                dynamic data = JsonConvert.DeserializeObject(requestBody);

                string email = data.email;

                if (email.EndsWith("@mentormate.com"))
                {
                    claimResponse.AppRole = "ADMIN";
                }
            }

            return new OkObjectResult(claimResponse);
        }
    }
}
