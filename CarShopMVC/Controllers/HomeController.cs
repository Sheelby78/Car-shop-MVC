using CarShopMVC.Models;
using CarShopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AllCars()
        {
            var cars = _carRepository.GetAll();
            return View(cars);
        }

        public IActionResult Details(int id) 
        {
            var car = _carRepository.GetCar(id);
            return View(car);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}