using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaxiManager.Models.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Model name is too long")]
        public string Model { get; set; } = null!;
        [Required]
        [DisplayName("License Plate")]
        [MaxLength(15, ErrorMessage = "License plate is too long")]
        public string LicensePlate { get; set; } = null!;
        [Required]
        [DisplayName("License Expiration Date")]
        public DateTime LicenseExpDate { get; set; }
        [DisplayName("Assigned Drivers")]
        public ICollection<Driver> AssignedDrivers { get; set; }

        public Car()
        {
            AssignedDrivers = new List<Driver>();
        }
    }
}
