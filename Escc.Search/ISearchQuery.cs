
namespace Escc.Search
{
    /// <summary>
    /// A query to be passed to a search service
    /// </summary>
    public interface ISearchQuery
    {
        /// <summary>
        /// Gets or sets the query text.
        /// </summary>
        /// <value>The query text.</value>
        string QueryTerms { get; set; }

        /// <summary>
        /// Gets or sets the query terms to search within a set of results.
        /// </summary>
        /// <value>The query within results terms.</value>
        string QueryWithinResultsTerms { get; set; }

        /// <summary>
        /// Gets or sets how many results are on each page.
        /// </summary>
        /// <value>The size of the page.</value>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the page of results to fetch.
        /// </summary>
        /// <value>The page.</value>
        int Page { get; set; }
    }
}
