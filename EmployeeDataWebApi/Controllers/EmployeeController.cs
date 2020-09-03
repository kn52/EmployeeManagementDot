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
                return this.Ok(new ResponseEntity(HttpStatusCode.Found, "Employee Data Found", EmployeeData));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found",null));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var EmployeeData = await Task.FromResult<Employee>(Service.GetEmployeeById(id));
            if (EmployeeData != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.Found,"Employee Data Found",EmployeeData));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found", null));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var employeeId = await Task.FromResult<string>(Service.AddEmployee(employee));
            if (employeeId != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.Created, "Record Inserted Successfully. ID = " + employeeId, 
                    null));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.NoContent,"Employee Record Not Added", null));
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> EditEmployee([FromBody] Employee employee)
        {
            var data = await Task.FromResult<bool>(Service.UpdateEmployee(employee));
            if (data)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Record Edited Successfully",null));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found",null));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var data = await Task.FromResult<bool>(Service.DeleteEmployee(id));
            if (data)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Record Deleted Successfully", null));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found", null));
        }
    }
}
