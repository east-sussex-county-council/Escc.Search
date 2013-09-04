
namespace Escc.Search
{
    /// <summary>
    /// A service which can cache search results using an <see cref="ICacheStrategy"/>
    /// </summary>
    public interface ICacheableService
    {
        /// <summary>
        /// Gets or sets the cache strategy.
        /// </summary>
        /// <value>The cache strategy.</value>
        ICacheStrategy CacheStrategy { get; set; }
    }
}
