using MGTConcerts.Models;
using MGTConcerts.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace MGTConcerts.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Artist> ArtistList = unitOfWork.Artist.GetAll(includeProperties: "Concerts").ToList();
            List<Concert> ConcertList = unitOfWork.Concert.GetAll().ToList();
            ViewBag.ConcertList= ConcertList;
            return View(ArtistList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            List<Order> orders = unitOfWork.Order.GetAll(u=> u.Email == userEmail, includeProperties: "Concert").ToList();

            return View(orders);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}