using System;
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
    public static class Function
    {
        [FunctionName("AppendRoleClaim")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            var claimResponse = new ClaimResponse { Extension_AppRole = "USER" };

            using (var reader = new StreamReader(req.Body))
            {
                var requestBody = await reader.ReadToEndAsync();

                dynamic data = JsonConvert.DeserializeObject(requestBody);

                string email = data.email;

                // note to self
                // the name of this property is by AZ B2C convention
                // extension_{b2c-extension-app}_{custom property name}

                string companyName = data.extension_f3f0fb7262d042f2bb4821baf1d050ce_CompanyName;

                if (email.EndsWith("@mentormate.com"))
                {
                    claimResponse.Extension_AppRole = "ADMIN";
                }
                else if (!string.IsNullOrEmpty(companyName))
                {
                    claimResponse.Extension_AppRole = "PROVIDER";
                }
            }

            return new OkObjectResult(claimResponse);
        }
    }
}
