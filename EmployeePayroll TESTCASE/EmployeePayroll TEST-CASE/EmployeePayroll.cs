using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll_TEST_CASE
{
    public class EmployeePayroll
    {
        public int ID { get; set; }

        public string Name { get;  set; }
        public DateTime Start { get;  set; }
        public long Salary { get;  set; }
        public string Gender { get; set; }
        public string Address { get;  set; }
        public string PhoneNumber { get;  set; }

        public static implicit operator EmployeePayroll(EmployeePayroll v)
        {
            throw new NotImplementedException();
        }
    }
}
