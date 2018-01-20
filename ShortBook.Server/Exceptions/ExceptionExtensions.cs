using System;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ILogger = NLog.ILogger;

namespace ShortBook.Server.Exceptions
{
    /// <summary>
    /// 异常扩展方法
    /// </summary>
    public static class ExceptionExtensions
    {
        private static readonly ILogger logger;

        static ExceptionExtensions()
        {
            logger = new LogFactory().GetLogger("ShortBook.Server.Error");
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static ActionResult Catch(this Exception ex)
        {
            logger.Error(ex);
            if (ex is ShortBookServerException)
            {
                if (ex is ShortBookServerUnauthorizedException)
                {
                    return new ErrorResult(401, ex);
                }
                if (ex is ShortBookServerForbiddenException)
                {
                    return new ErrorResult(403, ex);
                }
            }
            // 务器发生错误，用户将无法判断发出的请求是否成功
            return new ErrorResult(500, ex);
        }
    }
}