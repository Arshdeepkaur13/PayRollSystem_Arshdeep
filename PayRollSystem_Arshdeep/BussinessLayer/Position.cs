using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollSystem_Arshdeep.BussinessLayer
{
    public class Position
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
        public decimal DailyRate { get; set; }
        public Nullable<decimal> MonthlyRate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
