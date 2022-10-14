using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_Services_ADO.NET
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel=new EmployeeModel();    
                using(sqlConnection)
                {
                    string query = @"select EmployeeId,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,
	                                    Deduction,TaxablePay,Tax,NetPay,City,Country from Employee_PayRoll_Service";
                    SqlCommand cmd = new SqlCommand();
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeModel.EmployeeID = reader.GetInt32(0);
                            employeeModel.EmployeeName = reader.GetString(1);
                            employeeModel.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                            employeeModel.Address = Convert.ToString(reader["Address"]);
                            employeeModel.Department = Convert.ToString(reader["Department"]);
                            employeeModel.Gender = Convert.ToChar(reader["Gender"]);
                            employeeModel.BasicPay = Convert.ToDouble(reader["BasicPay"]);
                            employeeModel.Deduction = Convert.ToDouble(reader["Deduction"]);
                            employeeModel.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
                            employeeModel.Tax = Convert.ToDouble(reader["Tax"]);
                            employeeModel.NetPay = Convert.ToDouble(reader["NetPay"]);
                            employeeModel.City = Convert.ToString(reader["City"]);
                            employeeModel.Country = Convert.ToString(reader["Country"]);

                            Console.WriteLine("{0}  {1}  {2} ",employeeModel.EmployeeName,employeeModel.PhoneNumber,employeeModel.Address);
                        }
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using(sqlConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeedetails",sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Department", employeeModel.Department);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    command.Parameters.AddWithValue("@Deduction", employeeModel.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", employeeModel.Tax);
                    command.Parameters.AddWithValue("@NetPay",employeeModel.NetPay);
                    //command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    command.Parameters.AddWithValue("@City",employeeModel.City);
                    command.Parameters.AddWithValue("@Country", employeeModel.Country);

                    sqlConnection.Open();
                    var result=command.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    return false;   
                    sqlConnection.Close();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


    }
}
