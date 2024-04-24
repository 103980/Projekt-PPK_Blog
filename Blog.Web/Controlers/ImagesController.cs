using Blog.Web.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blog.Web.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository imageRepository;

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Ok("Images Get method");


        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
          var imageUrl = await imageRepository.UploadAsync(file);

            if (imageUrl == null)
            {
                return Problem("Nie udało sie dodać obrazu", null, (int)HttpStatusCode.InternalServerError);
            }

            return Json(new {link = imageUrl});
        }
    }
 }

