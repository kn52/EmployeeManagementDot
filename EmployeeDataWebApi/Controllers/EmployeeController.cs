namespace EmployeeDataWebApi.Controllers
{
    using EmployeeDataModel.Model;
    using EmployeeDataRepository.Model;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService service = new EmployeeService();
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var EmployeeData = service.GetAllEmployees();
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
            var EmployeeData = service.GetEmployeeById(id);
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
            var data = service.AddEmployee(employee);
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
            var data = service.UpdateEmployee(employee);
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
            var data = service.DeleteEmployee(id);
            if (data)
            {
                return this.Ok(new { data = "Deleted" });
            }
            return this.BadRequest(new { data = "Not Deleted" });
        }
    }
}
