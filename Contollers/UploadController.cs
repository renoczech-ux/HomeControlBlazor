using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using HomeControlBlazor.Services;

namespace HomeControlBlazor.Contollers
{
    [DisableRequestSizeLimit]
    
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly StudentInfo _studentInfo;
        private long maxFileSize = 1024 * 15;

        public UploadController(IWebHostEnvironment environment, StudentInfo studentinfo)
        {
            _environment = environment;
            _studentInfo = studentinfo;
        }

        #region "VSTE"
        [HttpPost("upload/single")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
        public IActionResult Single(IFormFile file)
        {
            try
            {
                //if (file.Length > 30000000)
                //{
                //    return StatusCode(413);
                //}
               UploadFile(file).GetAwaiter().GetResult();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }


       

        public async Task UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string customPath = _studentInfo.UploadFolder;
                var imagePath = @"\VSTE_data\Upload";
                if (customPath != "...")
                {
                    imagePath = string.Format("{0}\\{1}", imagePath, customPath);
                }
                
                var uploadPath = _environment.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath)) 
                {
                    Directory.CreateDirectory(uploadPath); 
                }

                var fullPath = Path.Combine(uploadPath, file.FileName);

                //await using FileStream fs = new(fullPath, FileMode.Create);
                //await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                    //file.CopyTo(fileStream);
                }

                //System.Threading.Thread.Sleep(1000);

                long origSize = file.Length;
                long copySize = fullPath.Length;

                var fullPathLog = Path.Combine(uploadPath, "log.txt");

                using (StreamWriter writer = new StreamWriter(fullPathLog, true))
                {
                    writer.WriteLine(string.Format("{0}~User:{1}~Folder:{2}~Filename:{3}~Size:{4}Byte~Description:{5}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _studentInfo.StudentName,
                        _studentInfo.UploadFolder, file.FileName, origSize, _studentInfo.FileDescription));                   
                }
            }
        }
        #endregion

        #region "VSE"
        [HttpPost("upload/singleVSE")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
        public IActionResult SingleVSE(IFormFile file)
        {
            try
            {
                //if (file.Length > 30000000)
                //{
                //    return StatusCode(413);
                //}
                UploadFileVSE(file).GetAwaiter().GetResult();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


       

        public async Task UploadFileVSE(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string customPath = _studentInfo.UploadFolder;
                var imagePath = @"\VSE_data\Upload";
                if (customPath != "...")
                {
                    imagePath = string.Format("{0}\\{1}", imagePath, customPath);
                }

                var uploadPath = _environment.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fullPath = Path.Combine(uploadPath, file.FileName);

                //await using FileStream fs = new(fullPath, FileMode.Create);
                //await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                    //file.CopyTo(fileStream);
                }

                //System.Threading.Thread.Sleep(1000);

                long origSize = file.Length;
                long copySize = fullPath.Length;

                var fullPathLog = Path.Combine(uploadPath, "log.txt");

                using (StreamWriter writer = new StreamWriter(fullPathLog, true))
                {
                    writer.WriteLine(string.Format("{0}~User:{1}~Folder:{2}~Filename:{3}~Size:{4}Byte~Description:{5}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _studentInfo.StudentName,
                        _studentInfo.UploadFolder, file.FileName, origSize, _studentInfo.FileDescription));
                }
            }
        }
        #endregion


        #region "Private"
        [HttpPost("upload/singlePrivatedata")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
        public IActionResult SinglePrivate(IFormFile file)
        {
            try
            {
                //if (file.Length > 30000000)
                //{
                //    return StatusCode(413);
                //}
                UploadFilePrivate(file).GetAwaiter().GetResult();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        public async Task UploadFilePrivate(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string customPath = _studentInfo.UploadFolder;
                var imagePath = @"\Private_data\Upload";
                if (customPath != "...")
                {
                    imagePath = string.Format("{0}\\{1}", imagePath, customPath);
                }

                var uploadPath = _environment.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fullPath = Path.Combine(uploadPath, file.FileName);

                //await using FileStream fs = new(fullPath, FileMode.Create);
                //await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                    //file.CopyTo(fileStream);
                }

                //System.Threading.Thread.Sleep(1000);

                long origSize = file.Length;
                long copySize = fullPath.Length;

                var fullPathLog = Path.Combine(uploadPath, "log.txt");

                using (StreamWriter writer = new StreamWriter(fullPathLog, true))
                {
                    writer.WriteLine(string.Format("{0}~User:{1}~Folder:{2}~Filename:{3}~Size:{4}Byte~Description:{5}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _studentInfo.StudentName,
                        _studentInfo.UploadFolder, file.FileName, origSize, _studentInfo.FileDescription));
                }
            }
        }
        #endregion

    }
}
