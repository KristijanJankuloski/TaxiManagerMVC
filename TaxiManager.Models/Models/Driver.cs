using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TaxiManager.Models.Enums;

namespace TaxiManager.Models.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "First name is too long")]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(25, ErrorMessage = "Last name is too long")]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(30, ErrorMessage = "Taxi license is too long")]
        [DisplayName("Taxi License")]
        public string TaxiLicense { get; set; } = null!;
        [Required]
        [DisplayName("License Expiration Date")]
        public DateTime LicenseExpDate { get; set; }
        public Shift? Shift { get; set; }
        public int? CarId { get; set; }
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
