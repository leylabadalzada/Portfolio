using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class ServiceController : Controller
    {
        readonly ISkillService _skillService;

        public ServiceController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _skillService.GetAllAsync();

            var grouped = result.Data
                .GroupBy(x => x.FieldId)
                .Select(g => new ServiceVM
                {
                    FieldId = g.Key,
                    Skills = g.ToList()
                }).ToList();

            return View(grouped);
        }
    }
}
