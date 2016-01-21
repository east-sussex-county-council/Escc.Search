
namespace Escc.Search
{
    /// <summary>
    /// A response from a search service, which can be cached using an <see cref="ICacheStrategy" />.
    /// </summary>
    public interface ICacheableResponse
    {
        /// <summary>
        /// Seralised response data returned by the search service
        /// </summary>
        string RawData();
    }
}
