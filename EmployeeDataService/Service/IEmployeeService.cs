namespace EmployeeDataRepository.Model
{
    using EmployeeDataModel.Model;
    using System.Collections.Generic;

    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int? id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int? id);
    }
}
