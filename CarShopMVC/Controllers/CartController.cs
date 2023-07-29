using System.Text.Json;
using CarShopMVC.Models;
using CarShopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MichalNajwerLab3.Controllers
{
    public class CartController : Controller
    {
        private const string ItemsList = "ItemsList";
        private readonly ICarRepository _carRepository;

        public CartController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sessionItems = HttpContext.Session.GetString(ItemsList);
            var items = string.IsNullOrEmpty(sessionItems)
                ? Enumerable.Empty<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(sessionItems);

            return View(items);
        }

        [HttpPost]
        public IActionResult AddItem(int itemId)
        {
            var car = _carRepository.GetCar(itemId);

            if (car == null)
                return BadRequest();

            var sessionItems = HttpContext.Session.GetString(ItemsList);
            var items = string.IsNullOrEmpty(sessionItems)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(sessionItems);

            var cartItem = items!.FirstOrDefault(i => i.Id == car.Id);

            if (cartItem == null)
            {
                items!.Add(new CartItem()
                {
                    Name = car.Model,
                    Price = car.Price,
                    Image = car.Image,
                    Count = 1,
                    Id = car.Id
                });
            }
            else
            {
                cartItem.Count += 1;
            }

            var serializedItems = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString(ItemsList, serializedItems);

            return Ok(cartItem);
        }

        [HttpPost]
        public IActionResult DeleteItem(int itemId)
        {
            var car = _carRepository.GetCar(itemId);

            if (car == null)
                return NotFound();

            var sessionItems = HttpContext.Session.GetString(ItemsList);

            if (string.IsNullOrEmpty(sessionItems))
                return BadRequest();

            var items = JsonSerializer.Deserialize<List<CartItem>>(sessionItems);

            var cartItem = items!.FirstOrDefault(i => i.Id == itemId);

            if (cartItem == null)
                return BadRequest();

            if(cartItem.Count > 0)
                cartItem.Count -= 1;

            if(cartItem.Count == 0)
                items!.Remove(cartItem);

            var serializedItems = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString(ItemsList, serializedItems);

            return Ok(cartItem);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder([Bind("Phone,City,Address,Id,Date")] Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            order.Id = Guid.NewGuid();
            order.Date = DateTime.Now;

            return View("PlacedOrder", order);
        }
    }
}
