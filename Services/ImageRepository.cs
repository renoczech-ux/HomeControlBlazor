using HomeControlBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControlBlazor.Services
{
    public interface IImageRespository
    {
        Task<List<ImageModel>> GetImages(string Folder);
        Task<List<SoundFileModel>> GetSoundFiles(string Folder);

        Task<List<VideoFileModel>> GetVideoFiles(string Folder);
    }

    public class ImageRepository : IImageRespository
    {

        public List<FileDescriptionModel> colFileDescriptions = new List<FileDescriptionModel>();

        private readonly IWebHostEnvironment _env;
        public ImageRepository(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }

        public async Task<List<ImageModel>> GetImages(string Folder)
        {
            if (colFileDescriptions != null)
            {
                GetPhotoDescription();
            }

            string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"images/" + Folder + "/"));
            List<ImageModel> imagelist = new List<ImageModel>();
            foreach (string filePath in filePaths)
            {
                var img = new ImageModel();
                img.Path = @"images/" + Folder + "/" + Path.GetFileName(filePath);
                img.ThumbnailPath = @"images/" + Folder + "/thumbnail/" + Path.GetFileName(filePath);
                img.Name = Path.GetFileName(filePath);
                img.Type = Path.GetExtension(filePath);
                if (colFileDescriptions.Any(id => id.ImageID == img.Name.Replace(img.Type, string.Empty)))
                {
                    img.Description = colFileDescriptions.Single(id => id.ImageID == img.Name.Replace(img.Type, string.Empty)).Description;
                }
                imagelist.Add(img);
            }
            return imagelist;
        }

        public async Task<List<SoundFileModel>> GetSoundFiles(string Folder)
        {
            try
            {
                //string[] filePaths =   Directory.GetFiles(@"\\trojan\bestama$\Programovani\HomeControlBlazor\HomeControlBlazor\wwwroot\soundfiles\tatka");
                //string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"/soundfiles/" + Folder + "/"));
                string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"soundfiles/" + Folder + "/"));
                List<SoundFileModel> imagelist = new List<SoundFileModel>();
                foreach (string filePath in filePaths)
                {
                    var soundFile = new SoundFileModel();
                    soundFile.Path = @"soundfiles/" + Folder + "/" + Path.GetFileName(filePath);
                    //img.ThumbnailPath = @"images/" + Folder + "/thumbnail/" + Path.GetFileName(filePath);
                    soundFile.Name = Path.GetFileName(filePath);
                    soundFile.Type = Path.GetExtension(filePath);
                    imagelist.Add(soundFile);
                }
                return imagelist;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        public async Task<List<VideoFileModel>> GetVideoFiles(string Folder)
        {
            try
            {
                //string[] filePaths =   Directory.GetFiles(@"\\trojan\bestama$\Programovani\HomeControlBlazor\HomeControlBlazor\wwwroot\soundfiles\tatka");
                //string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"/soundfiles/" + Folder + "/"));
                string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"video/" + Folder + "/"));
                List<VideoFileModel> videoFileList = new List<VideoFileModel>();
                foreach (string filePath in filePaths)
                {
                    var videoFile = new VideoFileModel();
                    videoFile.Path = @"video/" + Folder + "/" + Path.GetFileName(filePath);
                    //img.ThumbnailPath = @"images/" + Folder + "/thumbnail/" + Path.GetFileName(filePath);
                    videoFile.Name = Path.GetFileName(filePath);
                    videoFile.Type = Path.GetExtension(filePath);
                    videoFileList.Add(videoFile);
                }
                return videoFileList;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        private void GetPhotoDescription()
        {
            String line;
            try
            {
                string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"strings/"));
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePaths[0]);
                //Read the first line of text
                line = sr.ReadLine();


                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    string[] words = line.Split(':');
                    FileDescriptionModel imgDescription = new FileDescriptionModel();
                    imgDescription.ImageID = (words[0]);
                    imgDescription.Description = (words[1]);
                    colFileDescriptions.Add(imgDescription);
                    //Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
        }
        //public async Task<List<ImageModel>> GetImages(string Folder)
        //{
        //    string[] filePaths = Directory.GetFiles(Path.Combine(_env.WebRootPath, @"images/Hyundai"));
        //    List<ImageModel> imagelist = new List<ImageModel>();
        //    foreach (string filePath in filePaths)
        //    {
        //        var img = new ImageModel();
        //        img.Path = @"images/Hyundai/" + Path.GetFileName(filePath);
        //        img.ThumbnailPath = @"images/Hyundai/Thumbnail/" + Path.GetFileName(filePath);
        //        img.Name = Path.GetFileName(filePath);
        //        img.Type = Path.GetExtension(filePath);
        //        imagelist.Add(img);
        //    }
        //    return  imagelist;
        //}

        //public async Task<List<TblOte>> Get()
        //{
        //    //return await _context.TblOtes.ToListAsync();
        //    return null;
        //}


    }

   
}
