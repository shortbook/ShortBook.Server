using System;
using System.Runtime.Serialization;

namespace ShortBook.Server.Exceptions
{
    /// <summary>
    /// ShortBook异常类
    /// </summary>
    [Serializable]
    public class ShortBookServerException : ApplicationException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ShortBookServerException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public ShortBookServerException(string message) : base(message)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ShortBookServerException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ShortBookServerException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}