using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// ShortBook service base.
    /// </summary>
    public abstract class ShortBookServiceBase : IShortBookService
    {
        /// <summary>
        /// Get or set http context.
        /// </summary>
        public HttpContext Context { get; set; }

        /// <summary>
        /// Get or set logger.
        /// </summary>
        public ILogger Logger { get; set; }
    }
}