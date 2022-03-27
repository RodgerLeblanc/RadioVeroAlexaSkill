using Alexa.NET.Request.Type;

namespace RadioVeroAlexaSkill.RequestHandlers
{
    public abstract class BaseAudioRequestHandler<TRequest> : BaseRequestHandler<TRequest>
        where TRequest : Request
    {
        protected const string AudioUrl = "https://onlyguid.com/radiovero";
        protected const string Token = "0436EEF3-7571-489F-A3C2-3F6F062E9DB9";

        public BaseAudioRequestHandler(TRequest request) : base(request)
        {
        }
    }
}
