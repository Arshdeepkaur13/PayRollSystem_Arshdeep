using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollSystem_Arshdeep.BussinessLayer
{
    public class Employee
    {
        public int ID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
