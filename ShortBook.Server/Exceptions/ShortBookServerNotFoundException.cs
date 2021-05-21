using System;
using System.Runtime.Serialization;

namespace ShortBook.Server.Exceptions
{
    /// <summary>
    /// 表示指定的资源不存在（与404错误相对）。
    /// <para>403</para>
    /// </summary>
    public class ShortBookServerNotFoundException : ShortBookServerException
    {
        /// <inheritdoc />
        public ShortBookServerNotFoundException()
        {
        }

        /// <inheritdoc />
        public ShortBookServerNotFoundException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public ShortBookServerNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected ShortBookServerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
