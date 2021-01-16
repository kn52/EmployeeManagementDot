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
            DBString = this.Configuration["ConnectionStrings:DBConnection"];
        }
        public IConfiguration Configuration { get; set; }
        public IEnumerable<Employee> GetAllEmployees()
        {
            using (SqlConnection conn = new SqlConnection(this.DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllEmployees", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<Employee> employeeList = new List<Employee>();
                            while (rdr.Read())
                            {
                                Employee employee = new Employee
                                {
                                    ID = Convert.ToInt32(rdr["Id"]),
                                    FirstName = rdr["FName"].ToString(),
                                    LastName = rdr["LName"].ToString(),
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
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        public Employee GetEmployeeById(int? id)
        {
            using (SqlConnection conn = new SqlConnection(this.DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetEmployeeById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.AddWithValue("@EmpId", id);

                    try
                    {
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Employee employee = new Employee();
                            while (rdr.Read())
                            {
                                employee.ID = Convert.ToInt32(rdr["Id"]);
                                employee.FirstName = rdr["FName"].ToString();
                                employee.LastName = rdr["LName"].ToString();
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
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        public string AddEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(this.DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.AddWithValue("@FName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        string id = cmd.Parameters["@id"].Value.ToString();
                        if (id !=null)
                        {
                            return id;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        return null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(this.DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                    cmd.Parameters.AddWithValue("@FName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);

                    try
                    {
                        conn.Open();
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
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return false;
        }

        public bool DeleteEmployee(int? id)
        {
            using (SqlConnection conn = new SqlConnection(this.DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.AddWithValue("@EmpId", id);

                    try
                    {
                        conn.Open();
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
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return false;
        }

        private readonly string DBString;
    }
}
