namespace EmployeeDataRepository.Model
{
    using System.Collections.Generic;
    using EmployeeDataModel.Model;
    using EmployeeDataRepository.Repository;
    
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return Repository.GetAllEmployees();
        }
        public Employee GetEmployeeById(int? id)
        {
            return Repository.GetEmployeeById(id);
        }
        public bool AddEmployee(Employee employee)
        {
           return Repository.AddEmployee(employee);
        }
        public bool UpdateEmployee(Employee employee)
        {
            return Repository.UpdateEmployee(employee);
        }
        public bool DeleteEmployee(int? id)
        {
            return Repository.DeleteEmployee(id);
        }

        private IEmployeeRepository Repository = new EmployeeRepository();
    }
}
