using CarShopMVC.Models;

namespace CarShopMVC.Repositories
{
    public class FakeCarRepository : ICarRepository
    {
        private readonly ICollection<Car> cars = new List<Car>()
        {
            new (1, "Bugatti", "Chiron", 2000000, "chiron.jpg", 1600),
            new (2, "Koenigsegg", "Regera", 1900000, "reggera.jpg", 1500),
            new (3, "Lamborghini", "Huracan", 400000, "huracan.jpg", 572),
            new (4, "Volkswagen", "Passat", 2000, "passat.jpg", 105)
        };

        public IEnumerable<Car> GetAll()
        {
            return cars.ToList();
        }

        public Car GetCar(int id) 
        {
            return cars.FirstOrDefault(Car => Car.Id == id);
        }

        public Car GetCar(string id)
        {
            return GetCar(id);
        }
    }
}
