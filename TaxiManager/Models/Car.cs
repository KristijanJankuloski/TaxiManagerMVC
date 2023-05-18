namespace TaxiManager.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
        public DateTime LicenseExpDate { get; set; }
        public ICollection<Driver> AssignedDrivers { get; set; }

        public Car()
        {
            AssignedDrivers = new List<Driver>();
        }
    }
}
