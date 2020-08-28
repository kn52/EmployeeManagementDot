namespace EmployeeDataRepository.Repository
{
    using EmployeeDataModel.Model;
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int? id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int? id);
    }
}
