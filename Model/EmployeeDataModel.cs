using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EmplyeeDetail.Models
{
    public class EmployeeDataModel
    {
       
        public int EmployeelD { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string HiredDate { get; set; }

        [Required]
        public string Salary { get; set; } 

}
}