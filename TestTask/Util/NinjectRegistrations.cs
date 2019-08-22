using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Data.Models.Repositories;

namespace TestTask.Util
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IFilmsRepository>().To<FilmsRepository>();
            Bind<IFilesManager>().ToMethod(c => FilesManager.Instance);
        }
    }
}