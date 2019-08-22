using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TestTask.Util
{
    public interface IFilesManager
    {
        void Delete(string fileName);
        string SavePostFile(HttpPostedFileWrapper file);
        string GetLocalFileName(string fileName);
    }
    public class FilesManager : IFilesManager
    {
        private readonly string assetsPath = HttpContext.Current.Server.MapPath("~/Files");
        private static FilesManager instance;
        private FilesManager()
        {
            if (!Directory.Exists(assetsPath))
            {
                Directory.CreateDirectory(assetsPath);
            }
        }
        public static FilesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FilesManager();
                }
                return instance;
            }
        }

        public void Delete(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
            {
                return;
            }

            string fileName = GetLocalFileName(fileUrl);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        /// <summary>
        /// Сохраняет файл и возвращает ссылку на него
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Относительная ссылка на файл</returns>
        public string SavePostFile(HttpPostedFileWrapper file)
        {
            var todayDir = DateTime.Now.ToString("yyyyMMdd") + "/";
            var filesDir = assetsPath + "/" + todayDir;

            if (!Directory.Exists(filesDir))
            {
                Directory.CreateDirectory(filesDir);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            file.SaveAs(filesDir + fileName);

            return "~/Files/" + todayDir + fileName;
        }

        public string GetLocalFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return fileName;
            }
            if (fileName.StartsWith("~/Files/"))
            {
                return fileName;
            }
            if (fileName.StartsWith("/"))
            {
                return "~/Files" + fileName;
            }
            return "~/Files/" + fileName; 
        }
    }
}