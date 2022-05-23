using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using d1.Repos;
using d1.Model;
using System.Collections.Generic;
using System;

namespace d1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(employeeRepo.GetAll());
        }

        [HttpGet("{id:int}", Name = "getEmployee")]
        public IActionResult getEmployee(int id)
        {
            Employee emp = employeeRepo.FindById(id);
            if (emp==null)
            {
                return BadRequest("the id doesn't exist");
            }
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult addEmployee(Employee employee)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            employeeRepo.Insert(employee);
            string uri = Url.Link("getEmployee", new { id = employee.Id });
            return Created(uri, employee);
        }

        [HttpPut("{id:int}")]
        public IActionResult editEmployee(int id, Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                if (employeeRepo.FindById(id) == null) return BadRequest("the id doesn't exist");
                
                return Ok(employeeRepo.Edit(id, employee));
            }
                return BadRequest(ModelState);
        }



        [HttpDelete("{id:int}")]
        public IActionResult deleteEmployee(int id)
        {
            if (employeeRepo.FindById(id)==null)
            {
                return BadRequest("the id doesn't exist");
            }
            return Ok(employeeRepo.Delete(id));
        }
    }
}
