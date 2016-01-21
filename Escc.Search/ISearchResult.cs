
using System;
namespace Escc.Search
{
    /// <summary>
    /// A search result returned by a search service
    /// </summary>
    public interface ISearchResult
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the excerpt.
        /// </summary>
        /// <value>The excerpt.</value>
        string Excerpt { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        Uri Url { get; set; }
    }
}
