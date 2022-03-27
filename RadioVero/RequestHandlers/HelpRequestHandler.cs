using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RadioVeroAlexaSkill.RequestHandlers
{
    public class HelpRequestHandler : BaseRequestHandler<IntentRequest>
    {
        public HelpRequestHandler(IntentRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            string speechText = "Vous pouvez demander : Démarrer Radio Véro Bouchard.";
            SkillResponse response = ResponseBuilder.Tell(speechText);

            return new OkObjectResult(response);
        }
    }
}
