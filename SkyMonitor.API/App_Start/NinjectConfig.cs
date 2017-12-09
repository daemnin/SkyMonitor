using Ninject;
using Ninject.Web.Common;
using SkyMonitor.Data;
using SkyMonitor.Data.Contracts;
using SkyMonitor.Model;
using SkyMonitor.Model.Contracts;
using System.Reflection;

namespace SkyMonitor.API
{
    internal class NinjectConfig
    {
        internal static IKernel Configure()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IContext>().To<SkyMonitorContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}