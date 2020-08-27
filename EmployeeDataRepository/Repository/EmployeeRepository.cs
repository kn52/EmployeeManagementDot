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
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
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

        private readonly string DBString = "Data Source=KNKNS;Initial Catalog=aashish;Integrated Security=True";
    }
}
