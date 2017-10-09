using System;
using NUnit.Framework;
using ShortBook.Server.Domain.User;
using ShortBook.Server.Repository;

namespace ShortBook.Server.Tests.Repository
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            RepositoryFactory.Setup(new RepositoryModule());
        }

        [Test]
        public void GetTest()
        {
            UserRepository vc = new UserRepository();
            User user = new User()
            {
                Name = "name",
                Username = "username",
                Password = "password",
                LogonDate = DateTime.Today
            };
            vc.Add(user);
        }
    }
}