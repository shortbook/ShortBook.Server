using Microsoft.AspNetCore.Http;

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
    }
}