using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// ShortBook service interface.
    /// </summary>
    public interface IShortBookService
    {
        /// <summary>
        /// Get or set http context.
        /// </summary>
        HttpContext Context { get; set; }

        /// <summary>
        /// Get or set logger.
        /// </summary>
        ILogger Logger { get; set; }
    }
}