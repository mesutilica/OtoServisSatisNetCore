using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.ExtensionMethods;

namespace OtoServisSatis.WebUI.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ICarService _serviceArac;

        public FavoritesController(ICarService serviceArac)
        {
            _serviceArac = serviceArac;
        }

        public IActionResult Index()
        {
            var favoriler = GetFavorites();
            return View(favoriler);
        }

        private List<Arac> GetFavorites()
        {
            List<Arac>? araclar = new();
            araclar = HttpContext.Session.GetJson<List<Arac>>("GetFavorites");
            return araclar ?? new List<Arac>();
        }
        public IActionResult Add(int aracId)
        {
            try
            {
                var arac = _serviceArac.Find(aracId);
                var favoriler = GetFavorites();
                if (arac != null && !favoriler.Any(a => a.Id == aracId))
                {
                    favoriler.Add(arac);
                    HttpContext.Session.SetJson("GetFavorites", favoriler);
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!</div>";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int aracId)
        {
            try
            {
                var arac = _serviceArac.Find(aracId);
                var favoriler = GetFavorites();
                if (arac != null && favoriler.Any(a => a.Id == aracId))
                {
                    favoriler.RemoveAll(a => a.Id == aracId);
                    HttpContext.Session.SetJson("GetFavorites", favoriler);
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!</div>";
            }
            return RedirectToAction("Index");
        }
    }
}
