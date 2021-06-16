using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.Controllers
{
    public class UploadController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        [Obsolete]
        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        //http://localhost/Upload/ImageUpload --Route--->//http://localhost/api/upload
        [HttpPost, Route("api/upload")]
        [Obsolete]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            //# 이미지나 파일을 업로드할때 필요한 구성
            //1. path - 위치
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            //2. name - 유일한이름, DateTime, GUID            
            //3. extension - jpg,png...txt
            //image.jpg
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new { file="/images/upload/" + fileName, sucess = true});

            // # URL 접근방식
            // ASP.NET - 호스트명 /api/upload
            // JavaScript - 호스트명 + /+api/upload
        }
    }
}
