using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayroll_TEST_CASE
{
    public class EmployeePayrollServices
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;";
        public string AddEmployeeInDB(EmployeePayroll employeePayroll)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPAddNewEmployee", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employeePayroll.ID);
                    command.Parameters.AddWithValue("@EmployeeName", employeePayroll.Name);
                    command.Parameters.AddWithValue("@Gender", employeePayroll.Gender);
                    command.Parameters.AddWithValue("@PhoneNO", employeePayroll.PhoneNumber);
                    command.Parameters.AddWithValue("@EmployeeAddress", employeePayroll.Address);
                    command.Parameters.AddWithValue("@StartDate", employeePayroll.Start);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Added Successfully");
                        return "Added";
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                        return "Not Added";
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
      
    }
}


