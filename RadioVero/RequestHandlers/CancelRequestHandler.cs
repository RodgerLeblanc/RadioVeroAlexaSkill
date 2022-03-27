using Alexa.NET;
using Alexa.NET.Request.Type;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RadioVeroAlexaSkill.RequestHandlers
{
    public class CancelRequestHandler : BaseRequestHandler<IntentRequest>
    {
        public CancelRequestHandler(IntentRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            string speechText = "D'accord.";
            Alexa.NET.Response.SkillResponse response = ResponseBuilder.Tell(speechText);

            return new OkObjectResult(response);
        }
    }
}
