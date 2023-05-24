using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models.Models;

namespace TaxiManager.Models.ViewModels
{
    public class AssignDriverVM
    {
        public Driver Driver { get; set; }
        public List<Car> Cars { get; set; }
        public AssignDriverVM(Driver driver, List<Car> cars)
        {
            Driver = driver;
            Cars = cars;
        }
    }
}
