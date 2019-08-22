using Ninject.Modules;
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