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
        public IActionResult Get()
        {
            var EmployeeData = repository.GetAllEmployees();
            if (EmployeeData != null)
            {
                return this.Ok(new { data = EmployeeData });
            }
            return this.BadRequest(new { data = "No Record Found" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var EmployeeData = repository.GetEmployeeById(id);
            if (EmployeeData != null)
            {
                return this.Ok(new { Data = EmployeeData });
            }
            return this.BadRequest(new { Data = "No Record Found" });
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var data = repository.AddEmployee(employee);
            if (data)
            {
                return this.Ok(new { data = "Added" });
            }
            return this.BadRequest(new { data = "Not Added" });
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            var data = repository.UpdateEmployee(employee);
            if (data)
            {
                return this.Ok(new { data = "Edited" });
            }
            return this.BadRequest(new { data = "Not Edited" });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = repository.DeleteEmployee(id);
            if (data)
            {
                return this.Ok(new { data = "Deleted" });
            }
            return this.BadRequest(new { data = "Not Deleted" });
        }
    }
}
