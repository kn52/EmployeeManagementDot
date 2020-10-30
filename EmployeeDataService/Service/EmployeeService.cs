namespace EmployeeDataService.Service
{
    using System.Collections.Generic;
    using EmployeeDataModel.Model;
    using EmployeeDataRepository.Repository;
    
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository)
        {
            this.EmployeeRepository = repository;
        }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return EmployeeRepository.GetAllEmployees();
        }
        public Employee GetEmployeeById(int? id)
        {
            return EmployeeRepository.GetEmployeeById(id);
        }
        public string AddEmployee(Employee employee)
        {
           return EmployeeRepository.AddEmployee(employee);
        }
        public bool UpdateEmployee(Employee employee)
        {
            return EmployeeRepository.UpdateEmployee(employee);
        }
        public bool DeleteEmployee(int? id)
        {
            return EmployeeRepository.DeleteEmployee(id);
        }
    }
}
