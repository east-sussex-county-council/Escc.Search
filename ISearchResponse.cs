using System.Collections.Generic;

namespace Escc.Search
{
    /// <summary>
    /// A response from a search service, containing results and associated metadata
    /// </summary>
    public interface ISearchResponse
    {
        /// <summary>
        /// Gets or sets the total number of results.
        /// </summary>
        /// <value>The total results.</value>
        int TotalResults { get; }

        /// <summary>
        /// Gets whether the results found by the search service are available for display.
        /// </summary>
        /// <value><c>true</c> if results are available; <c>false</c> otherwise.</value>
        bool ResultsAvailable { get; }

        /// <summary>
        /// Gets the results of the search
        /// </summary>
        /// <returns></returns>
        IList<ISearchResult> Results();

        /// <summary>
        /// Gets spelling suggestions for the supplied search term.
        /// </summary>
        /// <returns></returns>
        IList<string> SpellingSuggestions();

    }
}
