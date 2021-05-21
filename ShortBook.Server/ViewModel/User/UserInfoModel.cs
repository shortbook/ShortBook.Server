using System;

namespace ShortBook.Server.ViewModel.User
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime LogonDate { get; set; }
    }
}