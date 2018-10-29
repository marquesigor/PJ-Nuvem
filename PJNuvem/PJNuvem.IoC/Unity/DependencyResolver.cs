using Microsoft.Practices.Unity;
using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Interfaces.Repositories.Base;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Domain.Service;
using PJNuvem.Infra.Data.Contexts;
using PJNuvem.Infra.Data.Repositories;
using PJNuvem.Infra.Data.Repositories.Base;
using PJNuvem.Infra.Transactions;
using prmToolkit.NotificationPattern;
using System.Data.Entity;

namespace PJNuvem.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, PJNuvemContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            container.RegisterType<IServiceUsuario, ServiceUsuario>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicePerfil, ServicePerfil>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceCompetencia, ServiceCompetencia>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceClasseProcessual, ServiceClasseProcessual>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceClasseProcessualCompetencia, ServiceClasseProcessualCompetencia>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceProcesso, ServiceProcesso>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceComarca, ServiceComarca>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceVara, ServiceVara>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceVaraCompetencia, ServiceVaraCompetencia>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryUsuario, RepositoryUsuario>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryPerfil, RepositoryPerfil>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryClasseProcessual, RepositoryClasseProcessual>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryClasseProcessualCompetencia, RepositoryClasseProcessualCompetencia>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryProcesso, RepositoryProcesso>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryCompetencia, RepositoryCompetencia>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryComarca, RepositoryComarca>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryVara, RepositoryVara>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryVaraCompetencia, RepositoryVaraCompetencia>(new HierarchicalLifetimeManager());
        }
    }
}
