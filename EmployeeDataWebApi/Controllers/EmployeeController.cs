namespace EmployeeDataWebApi.Controllers
{
    using EmployeeDataModel.Model;
    using EmployeeDataRepository.Model;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IEmployeeService service)
        {
            this.Service = service;
        }
        public IEmployeeService Service { get; set; }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var EmployeeData = await Task.FromResult<IEnumerable<Employee>>(Service.GetAllEmployees()) ;
            if (EmployeeData != null)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Message="Employee Data Found", Data = EmployeeData });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Message = "No Record Found",Data = "" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var EmployeeData = await Task.FromResult<Employee>(Service.GetEmployeeById(id));
            if (EmployeeData != null)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Message = "Employee Data Found", Data = EmployeeData });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Message = "No Record Found", Data = "" });
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var data = await Task.FromResult<bool>(Service.AddEmployee(employee));
            if (data)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Message = "Employee Added Successfully", Data = "" });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Message = "Employee Record Not Added", Data = "" });
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> EditEmployee([FromBody] Employee employee)
        {
            var data = await Task.FromResult<bool>(Service.UpdateEmployee(employee));
            if (data)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Message = "Employee Record Edited Successfully", Data = "" });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Message = "No Record Found", Data = "" });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var data = await Task.FromResult<bool>(Service.DeleteEmployee(id));
            if (data)
            {
                return this.Ok(new { Status = HttpStatusCode.OK, Message = "Employee Record Deleted Successfully", Data = "" });
            }
            return this.BadRequest(new { Status = HttpStatusCode.NoContent, Message = "No Record Found", Data = "" });
        }
    }
}
