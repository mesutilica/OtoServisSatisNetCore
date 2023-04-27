using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Controllers
{
    public class AracController : Controller
    {
        private readonly IService<Arac> _serviceArac;

        public AracController(IService<Arac> serviceArac)
        {
            _serviceArac = serviceArac;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _serviceArac.FindAsync(id);
            return View(model);
        }
    }
}
