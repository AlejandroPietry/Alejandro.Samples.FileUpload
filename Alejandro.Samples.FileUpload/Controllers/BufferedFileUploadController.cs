using Alejandro.Samples.FileUpload.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alejandro.Samples.FileUpload.Controllers
{
    public class BufferedFileUploadController : Controller
    {
        readonly IBufferedFileUploadService _bufferedFileUploadService;

        public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                bool fileUploadSuccess = await _bufferedFileUploadService.UploadFile(file);

                if (fileUploadSuccess)
                {
                    ViewBag.Message = "File upload successful";
                }
                else
                {
                    ViewBag.Message = "File upload Failed";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "File upload Failed";
            }

            return View();
        }
    }
}
