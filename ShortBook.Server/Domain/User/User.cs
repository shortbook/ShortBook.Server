using System;
using System.ComponentModel.DataAnnotations.Schema;
using ShortBook.Server.Exception;
using ShortBook.Server.Repository;

namespace ShortBook.Server.Domain.User
{
    [Table("User")]
    public class User : Entity
    {
        private readonly IUserRepository _repository;

        public User()
        {
            _repository = RepositoryFactory.Create<IUserRepository>();
        }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime LogonDate { get; set; }

        public bool Login()
        {
            var user = _repository.Get(Username, Password);
            if (user == null)
            {
                return false;
            }
            Id = user.Id;
            Name = user.Name;
            Username = user.Username;
            Password = user.Password;
            LogonDate = user.LogonDate;
            return true;
        }

        public void Register()
        {
            LogonDate = DateTime.Today;
            _repository.Add(this);
        }

        public void ChangePassword(string newPassword)
        {
            if (string.CompareOrdinal(Password, newPassword) == 0)
            {
                throw new ShortBookServerException("新密码不能与旧密码相同。");
            }
            _repository.Modify(this);
        }
    }
}