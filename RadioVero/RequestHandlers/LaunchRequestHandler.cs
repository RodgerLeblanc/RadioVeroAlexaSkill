using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RadioVeroAlexaSkill.RequestHandlers
{
    public class LaunchRequestHandler : BaseAudioRequestHandler<LaunchRequest>
    {
        public LaunchRequestHandler(LaunchRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            SkillResponse response = ResponseBuilder.AudioPlayerPlay(Alexa.NET.Response.Directive.PlayBehavior.ReplaceAll, AudioUrl, Token);

            return new OkObjectResult(response);
        }
    }
}
