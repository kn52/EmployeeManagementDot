namespace EmployeeDataRepository.Repository
{
    using EmployeeDataModel.Model;
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int? id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        void DeleteEmployee(int? id);
    }
}
