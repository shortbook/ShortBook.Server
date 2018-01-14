using System;
using System.Runtime.Serialization;

namespace ShortBook.Server.Exceptions
{
    /// <summary>
    /// 表示用户得到授权（与401错误相对），但是访问是被禁止的。
    /// <para>403</para>
    /// </summary>
    public class ShortBookServerForbiddenException : ShortBookServerException
    {
        /// <inheritdoc />
        public ShortBookServerForbiddenException()
        {
        }

        /// <inheritdoc />
        public ShortBookServerForbiddenException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public ShortBookServerForbiddenException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected ShortBookServerForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
