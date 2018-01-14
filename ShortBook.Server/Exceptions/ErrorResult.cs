using System;
using Microsoft.AspNetCore.Mvc;

namespace ShortBook.Server.Exceptions
{
    /// <summary>
    /// 异常结果
    /// </summary>
    public class ErrorResult : ObjectResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="ex">异常</param>
        public ErrorResult(int statusCode, Exception ex)
            : base(new {message = ex.Message})
        {
            StatusCode = statusCode;
        }
    }
}