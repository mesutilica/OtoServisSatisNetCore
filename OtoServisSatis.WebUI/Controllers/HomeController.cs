using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Models;
using System.Diagnostics;

namespace OtoServisSatis.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _service;
        private readonly IService<Arac> _serviceArac;

        public HomeController(IService<Slider> service, IService<Arac> serviceArac)
        {
            _service = service;
            _serviceArac = serviceArac;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _service.GetAllAsync(),
                Araclar = await _serviceArac.GetAllAsync(a => a.Anasayfa)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}