using Microsoft.AspNetCore.Http;

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
    }
}