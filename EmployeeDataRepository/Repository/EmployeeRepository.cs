namespace EmployeeDataRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using EmployeeDataModel.Model;
    using Microsoft.Extensions.Configuration;

    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
            DBString = this.Configuration["ConnectionString:DBConnection"];
        }
        public IConfiguration Configuration { get; set; }
        public IEnumerable<Employee> GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllEmployees", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    try
                    {
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<Employee> employeeList = new List<Employee>();
                            while (rdr.Read())
                            {
                                Employee employee = new Employee
                                {
                                    ID = Convert.ToInt32(rdr["Id"]),
                                    Name = rdr["Name"].ToString(),
                                    Email = rdr["Email"].ToString(),
                                    Password = rdr["Password"].ToString(),
                                    PhoneNumber = rdr["PhoneNumber"].ToString()
                                };
                                employeeList.Add(employee);
                            }
                            return employeeList;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return null;
                    }
                }
            }
            return null;
        }

        public Employee GetEmployeeById(int? id)
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetEmployeeById", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@EmpId", id);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Employee employee = new Employee();
                            while (rdr.Read())
                            {
                                employee.ID = Convert.ToInt32(rdr["Id"]);
                                employee.Name = rdr["Name"].ToString();
                                employee.Email = rdr["Email"].ToString();
                                employee.Password = rdr["Password"].ToString();
                                employee.PhoneNumber = rdr["PhoneNumber"].ToString();
                            }
                            return employee;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return null;
                    }
                }
            }
            return null;
        }

        public bool AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@Name", employee.Name);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@Password", employee.Password);
                        cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        con.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        return false;
                    }
                }
            }
            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                        cmd.Parameters.AddWithValue("@Name", employee.Name);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@Password", employee.Password);
                        cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        con.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return false;
                    }
                }
            }
            return false;
        }

        public bool DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@EmpId", id);
                        con.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return false;
                    }
                }
            }
            return false;
        }

        private readonly string DBString;
    }
}
