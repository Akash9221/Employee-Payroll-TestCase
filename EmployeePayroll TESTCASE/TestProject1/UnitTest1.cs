using EmployeePayroll_TEST_CASE;
using Intuit.Ipp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        EmployeePayrollServices employeePayrollServices = new EmployeePayrollServices();
        [TestMethod]
        public void AddEmployeeInDB()

        {
            EmployeePayroll employee = new EmployeePayroll()
            {
                ID = 1,
                Name = "Amit",
                PhoneNumber = "123456789",
                Address = "Rampuri Colony",
                Gender = "M",
                Start = DateTime.Now
            };
            string result=employeePayrollServices.AddEmployeeInDB(employee);
            Assert.AreEqual("Employee Added Successfully", result);
        }
        
    }
}
