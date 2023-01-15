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
        public string RetrieveEntriesFromEmployeePayDB()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<EmployeePayroll> employee = new List<EmployeePayroll>();
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeePayroll emp = new EmployeePayroll();
                            emp.ID = dr.GetInt32(0);
                            emp.Name = dr.GetString(1);
                            emp.Salary = dr.GetInt64(2);

                            emp.Start = dr.GetDateTime(3);

                            emp.Gender = dr.GetString(4);
                            emp.PhoneNumber = dr.GetString(5);
                            emp.Address = dr.GetString(6);
                            employee.Add(emp);
                        }
                        Console.WriteLine("ID" + " " + "Name" + "  " + "Salary" + "  " + "Start" + "  " + "Gender" + "  " + "  " + "PhoneNumber" + "" + "Address");
                        foreach (var data in employee)
                        {
                            Console.WriteLine(data.ID + " " + data.Name + "" + data.Salary + "" + data.Start + " " + data.Gender + "" + data.PhoneNumber + "" + data.Address);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
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
        public string UpdateDataInDatabase(EmployeePayroll employeepayroll)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeepayroll.Name);
                    command.Parameters.AddWithValue("@Address", employeepayroll.Address);
                    command.Parameters.AddWithValue("@Phone_No", employeepayroll.PhoneNumber);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Updated Successfully");
                        return "Update Succesfully";
                    }
                    else
                    {
                        Console.WriteLine("No DataBase found");
                        return "Not Update";
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
        public string DeleteDataFromDatabase(string name)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteDataFromDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);

                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {

                        Console.WriteLine("Employee Deleted Successfully");
                        return "Delete Succesfully";
                    }
                    else
                    {
                        Console.WriteLine("No DataBase found");
                        return "Not Delete";
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


