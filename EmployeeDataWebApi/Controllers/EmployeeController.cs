﻿namespace EmployeeDataWebApi.Controllers
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
        public void Post([FromBody] Employee employee)
        {
            repository;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
