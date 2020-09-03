namespace EmployeeDataRepository.Repository
{
    using EmployeeDataModel.Model;
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int? id);
        string AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int? id);
    }
}
