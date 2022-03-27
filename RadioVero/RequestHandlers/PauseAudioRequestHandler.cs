using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RadioVeroAlexaSkill.RequestHandlers
{
    public class PauseAudioRequestHandler : BaseAudioRequestHandler<IntentRequest>
    {
        public PauseAudioRequestHandler(IntentRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            SkillResponse response = ResponseBuilder.AudioPlayerStop();

            return new OkObjectResult(response);
        }
    }
}
