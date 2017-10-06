using Autofac;

namespace ShortBook.Server.Repository
{
    public static class RepositoryFactory
    {
        private static IContainer _container;

        public static void Setup(Module module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacModule());
            _container = builder.Build();
        }

        public static T Create<T>()
        {
            return _container.Resolve<T>();
        }
    }
}