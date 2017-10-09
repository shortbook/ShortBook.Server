using Autofac;
using ShortBook.Server.Repository;

namespace ShortBook.Server.Tests.Repository
{
    public class RepositoryTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}