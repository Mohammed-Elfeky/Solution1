using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using d1.Repos;
using d1.Model;
using d1.DTO;
using Microsoft.AspNetCore.Authorization;

namespace d1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;
        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo= departmentRepo;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(departmentRepo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult getDepartment(int id)
        {
            DeptWithEmpNames dept = departmentRepo.FindById(id);
            if (dept == null)
            {
                return BadRequest("the id doesn't exist");
            }
            return Ok(dept);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department d)
        {
            return Ok(new {id = departmentRepo.addDepartment(d)});
        }
    }
}
