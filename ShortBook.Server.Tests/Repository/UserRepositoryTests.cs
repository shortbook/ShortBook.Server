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
            IUserRepository repo = new UserRepository();
            User user = new User()
            {
                FirstName = "yunpeng",
                LastName = "gao",
                Email = "gaoyunpeng1982@gmail.com",
                Password = "password",
                LogonDate = DateTime.Today
            };
            repo.AddUser(user);

            Assert.IsTrue(repo.Validate(user));

            var getuser = repo.GetUser(user.Email, user.Password);
            Assert.IsNotNull(getuser);
            Assert.AreEqual(user.Id, getuser.Id);

            user.Password = "password2";
            repo.SetPassword(user);

            getuser = repo.GetUser(user.Id);
            Assert.IsNotNull(getuser);
            Assert.AreEqual(getuser.Password, "password2");
        }
    }
}