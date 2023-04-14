using Microsoft.AspNetCore.WebUtilities;

namespace Alejandro.Samples.FileUpload.Services.Interfaces
{
    public interface IStreamFileUploadService
    {
        Task<bool> UploadFile(MultipartReader reader, MultipartSection section);
    }
}
