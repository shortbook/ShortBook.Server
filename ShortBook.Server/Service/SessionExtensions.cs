using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// Session的扩展方法
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// 将对象保存到Session中
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 从Session中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}