using Microsoft.AspNetCore.Mvc;
using OSOS_Website.Models;
using System.Threading.Tasks;

namespace OSOS_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly FirebaseService _firebaseService;

        public HomeController()
        {
            _firebaseService = new FirebaseService();
        }

        public async Task<IActionResult> Index()
        {
            var ranking = await _firebaseService.GetGlobalRanking(10);
            ViewBag.Ranking = ranking;
            return View();
        }
    }
}