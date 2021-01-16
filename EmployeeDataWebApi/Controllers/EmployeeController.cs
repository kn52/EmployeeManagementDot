namespace EmployeeDataWebApi.Controllers
{
    using EmployeeDataModel.Model;
    using EmployeeDataService.Service;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using System;
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
        [Route("all")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var EmployeeData = await Task.FromResult(Service.GetAllEmployees());
                if (EmployeeData != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.Found, "Employee Data Found", EmployeeData));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "Bad Request", null));
            }
            
            return this.Ok(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found",null));
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var EmployeeData = await Task.FromResult<Employee>(Service.GetEmployeeById(id));
                if (EmployeeData != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.Found, "Employee Data Found", EmployeeData));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "Bad Request", null));
            }
            
            return this.Ok(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found", null));
        }

        // POST api/values
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                employee.Email = employee.Email.ToLower();
                var employeeId = await Task.FromResult(Service.AddEmployee(employee));
                if (employeeId != null && employeeId !="")
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.Created, "Record Inserted Successfully. ID = " + employeeId,
                        null));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "Bad Request", null));
            }
            
            return this.Ok(new ResponseEntity(HttpStatusCode.NoContent,"Employee Record Not Added", null));
        }

        // PUT api/values/5
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditEmployee([FromBody] Employee employee)
        {
            try
            {
                employee.Email = employee.Email.ToLower();
                var data = await Task.FromResult(Service.UpdateEmployee(employee));
                if (data)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Record Edited Successfully", null));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "Bad Request", null));
            }
            
            return this.Ok(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found",null));
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var data = await Task.FromResult<bool>(Service.DeleteEmployee(id));
                if (data)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Record Deleted Successfully", null));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "Bad Request", null));
            }

            return this.Ok(new ResponseEntity(HttpStatusCode.NoContent, "No Record Found", null));
        }
    }
}
