using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Util
{
    public interface IFileManage
    {
        void Delete(string fileName);
        string SavePostFile(HttpPostedFileWrapper file);
    }
    public class FileManager : IFileManage
    {
        public void Delete(string fileName)
        {
            throw new NotImplementedException();
        }

        public string SavePostFile(HttpPostedFileWrapper file)
        {
            throw new NotImplementedException();
        }
    }
}