namespace CarShopMVC.Models
{
    public class Car
    {
        public Car(int id, string brand, string model, decimal price, string image, int power)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
            Image = image;
            Power = power;
        }

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int Power { get; set; }

    }
}