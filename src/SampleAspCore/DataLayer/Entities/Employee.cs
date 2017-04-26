using System;
using System.Collections.Generic;

namespace SampleAspCore.DataLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public DateTime Dob { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Doh { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
