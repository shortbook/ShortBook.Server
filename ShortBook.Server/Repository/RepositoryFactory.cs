using Autofac;

namespace ShortBook.Server.Repository
{
    /// <summary>
    /// 持久化对象工厂
    /// </summary>
    public static class RepositoryFactory
    {
        private static IContainer _container;

        /// <summary>
        /// 使用指定对象映射模块初始化工厂
        /// </summary>
        /// <param name="module"></param>
        public static void Setup(Module module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            _container = builder.Build();
        }

        /// <summary>
        /// 创建一个持久化对象
        /// </summary>
        /// <typeparam name="T">持久化对象类型</typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : IRepository 
        {
            return _container.Resolve<T>();
        }
    }
}