namespace EmployeeDataRepository.Repository
{
    using EmployeeDataModel.Model;
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
