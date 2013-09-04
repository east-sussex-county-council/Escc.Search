
using System;
using System.IO;
using System.Web;
namespace Escc.Search
{
    /// <summary>
    /// Caches search results in a folder on the local file system
    /// </summary>
    public class FileCacheStrategy : ICacheStrategy
    {
        private string folderPath;
        private DateTime cacheThreshold;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCacheStrategy"/> class.
        /// </summary>
        /// <param name="folderPath">The path to the folder where cache files should be stored.</param>
        /// <param name="cacheTime">How long results can be cached for.</param>
        public FileCacheStrategy(string folderPath, TimeSpan cacheTime)
        {
            if (String.IsNullOrEmpty(folderPath)) throw new ArgumentNullException("folderPath");
            if (!Directory.Exists(folderPath)) throw new ArgumentException(folderPath + " does not exist", "folderPath");

            this.folderPath = folderPath;

            // Work out when is the oldest cached response that's still valid
            if (cacheTime == null) throw new ArgumentNullException("cacheTime");
            this.cacheThreshold = DateTime.UtcNow.Subtract(cacheTime);
        }

        /// <summary>
        /// Fetches the response from the cache if available.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The response if available, or <c>null</c> otherwise
        /// </returns>
        public string FetchCachedResponse(ISearchQuery query)
        {
            if (query == null) throw new ArgumentNullException("query");

            // Get the filename the response would've been cached as
            var filename = BuildCacheFilename(query);

            // If the file's not there, it's not cached
            if (!File.Exists(filename)) return null;

            // If the file's too old, it's not cached. (No point deleting it though, as it's about to get updated.)
            if (File.GetLastWriteTimeUtc(filename) < this.cacheThreshold) return null;

            // We have a new enough file, so return it.
            string rawData;
            using (var reader = new StreamReader(filename))
            {
                rawData = reader.ReadToEnd();
            }

            return rawData;
        }

        /// <summary>
        /// Caches a response to a search query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="System.IO.IOException">Thrown if the cache file cannot be written or if the disk is full</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if either paramter is null</exception>
        public void CacheResponse(ISearchQuery query, ICacheableResponse response)
        {
            if (query == null) throw new ArgumentNullException("query");
            if (response == null) throw new ArgumentNullException("response");

            // Get a unique filename
            var filename = BuildCacheFilename(query);
            try
            {
                // Write the file
                using (var writer = new StreamWriter(filename, false))
                {
                    writer.WriteLine(response.RawData());
                }
            }
            catch (ArgumentException)
            {
                // This search string isn't a valid filename.
                // Just do nothing - don't cache this one.
            }
            catch (PathTooLongException)
            {
                // This search string is reaaalllly long, so it isn't a valid filename.
                // Just do nothing - don't cache this one.
            }
        }

        /// <summary>
        /// Builds a filename unique to a particular search query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        private string BuildCacheFilename(ISearchQuery query)
        {
            // Build a filename which identifies the query. URL encoding should ensure a valid filename.
            var filename = HttpUtility.UrlEncode(query.QueryTerms);
            if (!String.IsNullOrEmpty(query.QueryWithinResultsTerms)) filename = filename + "#" + HttpUtility.UrlEncode(query.QueryWithinResultsTerms);
            filename = filename + "." + query.Page + "." + query.PageSize + ".cached";
            return this.folderPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + filename;
        }
    }
}
