using Alejandro.Samples.FileUpload.Services.Interfaces;

namespace Alejandro.Samples.FileUpload.Services
{
    public class BufferedFileUploadService : IBufferedFileUploadService
    {
        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = string.Empty;

            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));

                    if (Directory.Exists(path) == false)
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File copy Failed", ex);
            }
        }
    }
}
