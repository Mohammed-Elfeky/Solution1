using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using d1.Repos;
namespace d1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;
        public UploadController(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }
        [HttpPost("{id:int}")]
        public IActionResult uploadImage(int id)
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            departmentRepo.addDepartmentImge(id,fileName);
            return Ok(new { msg="uploaded" });
        }
    }
}
