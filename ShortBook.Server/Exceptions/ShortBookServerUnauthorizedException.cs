using System;
using System.Runtime.Serialization;

namespace ShortBook.Server.Exceptions
{
    /// <summary>
    /// 表示用户没有权限（令牌、用户名、密码错误）
    /// <para>401</para>
    /// </summary>
    public class ShortBookServerUnauthorizedException : ShortBookServerException
    {
        /// <inheritdoc />
        public ShortBookServerUnauthorizedException()
        {
        }

        /// <inheritdoc />
        public ShortBookServerUnauthorizedException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public ShortBookServerUnauthorizedException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected ShortBookServerUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}