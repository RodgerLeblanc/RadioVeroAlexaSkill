using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RadioVeroAlexaSkill.RequestHandlers
{
    public interface IRequestHandler
    {
        Task<IActionResult> GetResultAsync();
    }
}
