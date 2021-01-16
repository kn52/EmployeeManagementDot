namespace EmployeeManagementUnitTest
{
    using EmployeeDataModel.Model;
    using EmployeeDataService.Service;
    using EmployeeDataWebApi.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    public class EmployeeManagementTest
    {
        private EmployeeController EmployeeController;
        private List<Employee> employeeList;

        [SetUp]
        public void Setup()
        {
            employeeList = new List<Employee>
            {
                new Employee
                {
                    ID = 7,
                    FirstName = "Abhishek",
                    LastName = "Kumar",
                    Email = "abhi@gmail.com",
                    Password = "Abhi@123",
                    PhoneNumber = "8764769213"
                },
                new Employee
                {
                  ID = 8,
                  FirstName = "Stephen",
                  LastName = "Hawking",
                  Email = "stephen@gmail.com",
                  Password = "Steph@123",
                  PhoneNumber = "8946309274"
                },
                new Employee
                {
                  ID = 9,
                  FirstName = "Harry",
                  LastName = "Carter",
                  Email = "harrc@gmail.com",
                  Password = "Harrc@123",
                  PhoneNumber = "9846538234"
                },
                new Employee
                {
                  ID = 10,
                  FirstName = "Harry",
                  LastName = "Potter",
                  Email = "harrp@gmail.com",
                  Password = "Harrp@123",
                  PhoneNumber = "9876543215"
                }
            };
        }

        [Test]
        public async Task When_GetAllEmployees_ShouldReturn_AllEmployeesAsync()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.GetAllEmployees()).Returns(employeeList);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult) await EmployeeController.GetAllEmployee();
            ResponseEntity responseEntity = (ResponseEntity) actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.Found, responseEntity.httpStatusCode);
            Assert.AreEqual("Employee Data Found", responseEntity.message);
        }

        [Test]
        public async Task When_GetAllEmployees_ShouldReturn_NullEmployeesAsync()
        {
            List<Employee> list = null;
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.GetAllEmployees()).Returns(list);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.GetAllEmployee();
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.NoContent, responseEntity.httpStatusCode);
            Assert.AreEqual("No Record Found", responseEntity.message);
        }

        [Test]
        public async Task When_GetEmployeeById_ShouldReturn_SuccessResult()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(new Employee
            {
                ID = 10,
                FirstName = "Harry",
                LastName = "Potter",
                Email = "harrp@gmail.com",
                Password = "Harrp@123",
                PhoneNumber = "9876543215"
            });
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.GetEmployeeById(10);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.Found, responseEntity.httpStatusCode);
            Assert.AreEqual("Employee Data Found", responseEntity.message);
        }

        [Test]
        public async Task When_GetEmployeeById_ShouldReturn_NullResult()
        {
            Employee list = null;
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(list);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.GetEmployeeById(10);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.NoContent, responseEntity.httpStatusCode);
            Assert.AreEqual("No Record Found", responseEntity.message);
        }

        [Test]
        public async Task When_AddEmployee_ShouldReturn_SuccessMessage()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns("11");
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.AddEmployee(null);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.Created, responseEntity.httpStatusCode);
            Assert.AreEqual("Record Inserted Successfully. ID = 11", responseEntity.message);
        }

        [Test]
        public async Task When_AddEmployee_ShouldReturn_NotSuccessMessage()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns("");
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.AddEmployee(null);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.NoContent, responseEntity.httpStatusCode);
            Assert.AreEqual("Employee Record Not Added", responseEntity.message);
        }

        [Test]
        public async Task When_UpdateEmployee_ShouldReturn_SuccessMessage()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).Returns(true);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.EditEmployee(null);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, responseEntity.httpStatusCode);
            Assert.AreEqual("Employee Record Edited Successfully", responseEntity.message);
        }

        [Test]
        public async Task When_UpdateEmployee_ShouldReturn_NotSuccessMessage()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).Returns(false);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.EditEmployee(null);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.NoContent, responseEntity.httpStatusCode);
            Assert.AreEqual("No Record Found", responseEntity.message);
        }

        [Test]
        public async Task When_DeleteEmployee_ShouldReturn_SuccessMessage()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(true);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.DeleteEmployee(-1);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, responseEntity.httpStatusCode);
            Assert.AreEqual("Employee Record Deleted Successfully", responseEntity.message);
        }

        [Test]
        public async Task When_DeleteEmployee_ShouldReturn_NotSuccessMessage()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(false);
            EmployeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await EmployeeController.DeleteEmployee(-1);
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.NoContent, responseEntity.httpStatusCode);
            Assert.AreEqual("No Record Found", responseEntity.message);
        }
    }
}