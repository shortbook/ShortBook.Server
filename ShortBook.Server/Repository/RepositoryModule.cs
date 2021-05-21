using Autofac;
using ShortBook.Server.Repository.Npgsql;

namespace ShortBook.Server.Repository
{
    /// <summary>
    /// 仓储模块
    /// </summary>
    public class RepositoryModule : Module
    {
        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}