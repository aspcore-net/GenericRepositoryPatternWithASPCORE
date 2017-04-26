using System;

namespace SampleAspCore.DataLayer.Entities
{
    public class EmployeeDepartment
    {
        public int EmpId { get; set; }
        public string DeptId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
