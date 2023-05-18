using TaxiManager.Enums;

namespace TaxiManager.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string TaxiLicense { get; set; } = null!;
        public DateTime LicenseExpDate { get; set; }
        public Shift? Shift { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }

        public Driver(){}
        public Driver(string firstName, string lastName, string taxiLicense, DateTime expDate)
        {
            FirstName = firstName;
            LastName = lastName;
            TaxiLicense = taxiLicense;
            LicenseExpDate = expDate;
        }

        public LicenseStatus GetExpireStatus()
        {
            var today = DateTime.Today;
            if(LicenseExpDate < today)
                return LicenseStatus.Expired;
            if (LicenseExpDate < today.AddMonths(3))
                return LicenseStatus.Warning;
            return LicenseStatus.Valid;
        }
    }
}
