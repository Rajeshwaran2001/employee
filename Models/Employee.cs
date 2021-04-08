using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Models
{
    public class Employee
    {
        internal object id;

        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int PhoneNo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        
    }
}
