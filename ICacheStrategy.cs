
namespace Escc.Search
{
    /// <summary>
    /// A method of caching search results
    /// </summary>
    public interface ICacheStrategy
    {
        /// <summary>
        /// Fetches the response from the cache if available.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The response if available, or <c>null</c> otherwise</returns>
        string FetchCachedResponse(ISearchQuery query);

        /// <summary>
        /// Caches a response to a search query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="response">The response.</param>
        void CacheResponse(ISearchQuery query, ICacheableResponse response);
    }
}
