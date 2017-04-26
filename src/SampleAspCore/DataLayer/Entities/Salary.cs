using System;

namespace SampleAspCore.DataLayer.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
