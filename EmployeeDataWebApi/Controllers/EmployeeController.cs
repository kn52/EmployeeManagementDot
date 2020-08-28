namespace EmployeeDataWebApi.Controllers
{
    using System.Collections.Generic;
    using EmployeeDataModel.Model;
    using EmployeeDataRepository.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository repository = new EmployeeRepository();
        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return repository.GetAllEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return repository.GetEmployeeById(id);
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] Employee employee)
        {
            return repository.AddEmployee(employee);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            repository.UpdateEmployee(employee);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteEmployee(id);
        }
    }
}
