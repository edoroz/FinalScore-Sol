
using FinalScore_Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalScore_Web.Areas.Admin.Controllers {

    [Area("Admin")]
    public class EquiposController : Controller {
        private readonly IWorkUnit _workUnit;

        public EquiposController(IWorkUnit workUnit) {
            _workUnit = workUnit;
        }
                                                                [HttpGet]
        public IActionResult Index() {
            return View();
        }
                                                                [HttpGet]
        public IActionResult GetAll() { 
            var result = Json(new { data = _workUnit.Equipo.GetAll(includeProps:"Liga") });
            return result;
        }
    }
}
