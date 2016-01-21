
namespace Escc.Search
{
    /// <summary>
    /// A service which returns search results
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Run a query against the search service
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        ISearchResponse Search(ISearchQuery query);
    }
}
