using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Alexa.NET.Request;
using RadioVeroAlexaSkill.RequestHandlers;
using RadioVeroAlexaSkill.SkillHandlers;
using Alexa.NET;
using Alexa.NET.Response;
using System;
using Alexa.NET.Request.Type;

namespace RadioVeroAlexaSkill
{
    public static class RadioVero
    {
        [FunctionName(nameof(RadioVero))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                SkillRequest skillRequest = await GetSkillRequestFromRequest(req);

                bool isValid = await RequestHandlerHelper.ValidateRequest(req, log, skillRequest);
                if (!isValid)
                {
                    return new BadRequestResult();
                }

                if (RequestHandlerHelper.IsPlayAudioRequest(skillRequest.Request))
                {
                    var progressiveResponse = new ProgressiveResponse(skillRequest);

                    if (progressiveResponse.CanSend() && progressiveResponse.Client?.BaseAddress != null)
                    {
                        await progressiveResponse.SendSpeech("Démarrage de Radio Véro, une présentation de onlyguid.com.");
                    }
                }

                ISkillHandler skillHandler = new SkillHandler(skillRequest.Request);
                return await skillHandler.GetResultAsync();
            }
            catch (System.Exception e)
            {
                log.LogError(e.Message);

                string speechText = "Je n'ai pas réussi à comprendre votre demande.";

                SkillResponse response = ResponseBuilder.Ask(speechText, RequestHandlerHelper.GetDefaultReprompt());
                return new OkObjectResult(response);
            }
        }

        private static async Task<SkillRequest> GetSkillRequestFromRequest(HttpRequest req)
        {
            string json = await req.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SkillRequest>(json);
        }
    }
}
