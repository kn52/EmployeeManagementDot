namespace EmployeeDataRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using EmployeeDataModel.Model;
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (SqlConnection con = new SqlConnection(DBString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
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
            }
            return employeeList;
        }

        public Employee GetEmployeeById(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetEmployeeById", con)
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.ID = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Email = rdr["Email"].ToString();
                    employee.Password = rdr["Password"].ToString();
                    employee.PhoneNumber = rdr["PhoneNumber"].ToString();
                }
            }
            return employee;
        }

        private readonly string DBString = "Data Source=KNKNS;Initial Catalog=aashish;Integrated Security=True";
    }
}
