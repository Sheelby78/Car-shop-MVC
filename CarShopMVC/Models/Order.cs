using System.ComponentModel.DataAnnotations;

namespace CarShopMVC.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone(ErrorMessage = "Niepoprawny numer telefonu")]
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}
