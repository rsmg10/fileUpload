using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;



public class FileController : ControllerBase {

    [HttpPost("UploadAllFile")]
    [AllowAnonymous]
    public async Task<IActionResult> UploadFiles([FromForm] IFormFile  file)
    {
        try
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images/" + file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        return Ok(path);
        }
        catch (Exception)
        {

            throw;
        }
        

    }

    //[HttpPost("UploadImage")]
    //public ActionResult UploadImage(IFormFile file)
    //{

    //    //_logger.LogInformation(file.FileName);
    //    // we can put rest of upload logic here.
    //    return Ok();


    //}

}


// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Net.Http.Headers;

//namespace AspNetCoreFileUploading
//{
//    public class UploaderController : Controller
//    {
//        private IWebHostEnvironment hostingEnvironment;

//        public UploaderController(IWebHostEnvironment hostingEnvironment)
//        {
//            this.hostingEnvironment = hostingEnvironment;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(IList<IFormFile> files)
//        {
//            Startup.Progress = 0;

//            long totalBytes = files.Sum(f => f.Length);

//            foreach (IFormFile source in files)
//            {
//                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

//                filename = this.EnsureCorrectFilename(filename);

//                byte[] buffer = new byte[16 * 1024];

//                using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
//                {
//                    using (Stream input = source.OpenReadStream())
//                    {
//                        long totalReadBytes = 0;
//                        int readBytes;

//                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
//                        {
//                            await output.WriteAsync(buffer, 0, readBytes);
//                            totalReadBytes += readBytes;
//                            Startup.Progress = (int)((float)totalReadBytes / (float)totalBytes * 100.0);
//                            await Task.Delay(10); // It is only to make the process slower
//                        }
//                    }
//                }
//            }

//            return this.Content("success");
//        }

//        [HttpPost]
//        public ActionResult Progress()
//        {
//            return this.Content(Startup.Progress.ToString());
//        }

//        private string EnsureCorrectFilename(string filename)
//        {
//            if (filename.Contains("\\"))
//                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

//            return filename;
//        }

//        private string GetPathAndFilename(string filename)
//        {
//            string path = this.hostingEnvironment.WebRootPath + "\\uploads\\";

//            if (!Directory.Exists(path))
//                Directory.CreateDirectory(path);

//            return path + filename;
//        }
//    }
//}

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Formatters;

//namespace darweeshapi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet(Name = "sumapi")]
//        public int Sum(int first, int second)
//        {

//            return first + second;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(IList<IFormFile> files)
//        {
//            Startup.Progress = 0;

//            long totalBytes = files.Sum(f => f.Length);

//            foreach (IFormFile source in files)
//            {
//                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

//                filename = this.EnsureCorrectFilename(filename);

//                byte[] buffer = new byte[16 * 1024];

//                using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
//                {
//                    using (Stream input = source.OpenReadStream())
//                    {
//                        long totalReadBytes = 0;
//                        int readBytes;

//                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
//                        {
//                            await output.WriteAsync(buffer, 0, readBytes);
//                            totalReadBytes += readBytes;
//                            Startup.Progress = (int)((float)totalReadBytes / (float)totalBytes * 100.0);
//                            await Task.Delay(10); // It is only to make the process slower
//                        }
//                    }
//                }
//            }

//            return this.Content("success");
//        }

//        [HttpPost]
//        public ActionResult Progress()
//        {
//            return this.Content(Startup.Progress.ToString());


//        }
//    }
//}