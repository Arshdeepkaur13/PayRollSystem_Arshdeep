using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollSystem_Arshdeep.BussinessLayer
{
    public class Payroll
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public decimal NoOfLeaves { get; set; }
        public Nullable<decimal> GrossSalary { get; set; }
        public Nullable<decimal> TotalDeduction { get; set; }
        public Nullable<decimal> NetPay { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
