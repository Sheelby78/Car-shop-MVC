using CarShopMVC.Models;

namespace CarShopMVC.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();

        Car GetCar(int id);
    }
}
