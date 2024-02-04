using Microsoft.AspNetCore.Mvc;

namespace YourServerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            // Ensure the directory exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the path or any other information you deem necessary
            return Ok(new { filePath });
        }
    }
}

