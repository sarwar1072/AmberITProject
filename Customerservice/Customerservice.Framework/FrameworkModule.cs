using Autofac;
using Customerservice.Framework.Repositories;
using Customerservice.Framework.Services;
using CustomerService.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework
{
    public class FrameworkModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _webHostEnvironment;

        public FrameworkModule(string connectionString, string migrationAssemblyName,
            string webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SalesRepogitory>().As<ISalesRepogitory>()
                .InstancePerLifetimeScope();


            builder.RegisterType<ProjectUnitOfWork>().As<IProjectUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerLifetimeScope();
            builder.RegisterType< CustomerServices >().As<ICustomerServices>().InstancePerLifetimeScope();
            builder.RegisterType< SalesServices >().As< ISalesServices >().InstancePerLifetimeScope();  

            base.Load(builder);
        }
    }
}
