using System.ComponentModel;

namespace TaxiManager.Models.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        [DisplayName("License Plate")]
        public string LicensePlate { get; set; } = null!;
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
