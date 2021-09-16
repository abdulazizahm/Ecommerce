using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.AppServices
{
    public enum Directories {
        Users,
        Products,
        Sub_Categories,
        Main_Categories,
        Brands,
        Temp
    }


    public class ImageUploaderService
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public ImageUploaderService(HttpPostedFileBase file, Directories dir)
        {
            if (file != null)
            {
                string fullPath;
                fullPath = HttpContext.Current.Server.MapPath(("~/Content/Imgs/" + dir.ToString()));
                if (!System.IO.Directory.Exists(fullPath))
                {
                    System.IO.Directory.CreateDirectory(fullPath);
                }

                string[] extention = System.IO.Path.GetFileName(file.FileName).Split('.');
                FileName = Guid.NewGuid().ToString()+"."+extention[extention.Length-1];
                ImageFile = file;
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath(("~/Content/Imgs/" + dir.ToString())), FileName);
            }
            else
            {
                FileName = "default.jpg";
            }
        }

        public string GetImageName()
        {
            return FileName;
        }

        public void SaveImage()
        {
            ImageFile.SaveAs(FilePath);
        }

        public static void DeleteImage(string fileName, Directories dir)
        {
            var fullPath = HttpContext.Current.Server.MapPath(("~/Content/Imgs/"+dir.ToString()+fileName));

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        public static void RecreateFolder(Directories dir)
        {
            var fullPath = HttpContext.Current.Server.MapPath(("~/Content/Imgs/"+dir.ToString()));

            if (System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.Delete(fullPath, true);
            }

            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }


        }


    }


   
    

    

}