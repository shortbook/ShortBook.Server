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
        public void Test()
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

            var getuser = vc.Get("username", "password");
            Assert.IsNotNull(getuser);
            Assert.AreEqual(user.Id, getuser.Id);

            user.Password = "password2";
            vc.Modify(user);

            getuser = vc.Get("username", "password2");
            Assert.IsNotNull(getuser);
            Assert.AreEqual(user.Password, "password2");

            vc.Remove(user);

            getuser = vc.Get(user.Id);
            Assert.IsNull(getuser);
        }
    }
}