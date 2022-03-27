using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RadioVeroAlexaSkill.SkillHandlers
{
    public interface ISkillHandler
    {
        Task<IActionResult> GetResultAsync();
    }
}
