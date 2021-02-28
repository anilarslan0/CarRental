using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {

            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                    file.CopyTo(stream);

            var result = newPath(file);

            File.Move(sourcepath, result);

            return result;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            File.Copy(sourcePath, result);

            File.Delete(sourcePath);

            return result;
        }


        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string newPath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("D")
               + "-" + DateTime.Now.Month + "-"
               + DateTime.Now.Day + "-"
               + DateTime.Now.Year + fileExtension;

            string path = Path.Combine(Environment.CurrentDirectory + @"/wwwroot/Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }
    }
}
