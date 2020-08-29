namespace EmployeeDataWebApi.Controllers
{
    using EmployeeDataModel.Model;
    using EmployeeDataRepository.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IEmployeeService service)
        {
            this.Service = service;
        }
        public IEmployeeService Service { get; set; }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var EmployeeData = await Task.FromResult<IEnumerable<Employee>>(Service.GetAllEmployees()) ;
            if (EmployeeData != null)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, data = EmployeeData });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, data = "No Record Found" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var EmployeeData = await Task.FromResult<Employee>(Service.GetEmployeeById(id));
            if (EmployeeData != null)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Data = EmployeeData });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Data = "No Record Found" });
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var data = await Task.FromResult<bool>(Service.AddEmployee(employee));
            if (data)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Data = "Employee Added" });
            }
            return this.BadRequest(new { Status = HttpStatusCode.BadRequest, Data = "Employee Not Added" });
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            var data = await Task.FromResult<bool>(Service.UpdateEmployee(employee));
            if (data)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Data = "Employee Record Edited" });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Data = "Not Found" });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Task.FromResult<bool>(Service.DeleteEmployee(id));
            if (data)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Data = "Employee Record Deleted" });
            }
            return this.BadRequest(new { Status = HttpStatusCode.OK, Data = "Not Found" });
        }
    }
}
