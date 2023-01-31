using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SignInUpProxy
{
    public static class AppendRoleClaim
    {
        [FunctionName("AppendRoleClaim")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var appRole = "USER";

            using (var reader = new StreamReader(req.Body))
            {
                var requestBody = await reader.ReadToEndAsync();

                dynamic data = JsonConvert.DeserializeObject(requestBody);

                string email = data.email;


                if (email.EndsWith("@mentormate.com"))
                {
                    appRole = "ADMIN";
                }
            }

            return new OkObjectResult(new { appRole });
        }
    }
}
