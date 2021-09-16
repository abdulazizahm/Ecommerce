using BL.AppServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [AllowAnonymous]
        [HttpPost]
        public string Upload(HttpPostedFileBase imageFile)
        {
            ImageUploaderService imageUploaderService = new ImageUploaderService(imageFile, Directories.Temp);
            imageUploaderService.SaveImage();

            return $"/Content/Imgs/Temp/{imageUploaderService.GetImageName()}";
        }
    }
}