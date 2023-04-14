using Alejandro.Samples.FileUpload.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Alejandro.Samples.FileUpload.Controllers
{
    public class StreamFileUploadController : Controller
    {
        readonly IStreamFileUploadService _streamFileUploadService;

        public StreamFileUploadController(IStreamFileUploadService streamFileUploadService)
        {
            _streamFileUploadService = streamFileUploadService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Index")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 524288000)]
        public async Task<IActionResult> SaveFileToPhysicalFolder()
        {
            var boundary = HeaderUtilities.RemoveQuotes(
                MediaTypeHeaderValue.Parse(Request.ContentType).Boundary).Value;

            var reader = new MultipartReader(boundary, Request.Body);
            var section = await reader.ReadNextSectionAsync();

            string response = string.Empty;

            try
            {
                bool sucessFileSave = await _streamFileUploadService.UploadFile(reader, section);
                
                if (sucessFileSave)
                    ViewBag.Message = "File Upload Successful";
                else
                    ViewBag.Message = "File Upload Failed";
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
    }
}
