namespace YousicianAssignment.Yle
{
    public class YleApiQueryFormatter
    {
        /// <summary>
        /// The API format for a query
        /// </summary>
        private const string SEARCH_PRORGAMS =
            "https://external.api.yle.fi/v1/programs/items.json?q={2}&app_key={0}&app_id={1}";

        /// <summary>
        /// The app id used to access the api
        /// </summary>
        private readonly string appId;
        
        /// <summary>
        /// The app key used to access the api
        /// </summary>
        private readonly string appKey;
        
        public YleApiQueryFormatter(string appid, string appkey)
        {
            appId = appid;
            appKey = appkey;
        }

        /// <summary>
        /// Formats the query in line with the api
        /// </summary>
        public string CreateSearchProgramsUri(string searchTerm)
        {
            return string.Format(SEARCH_PRORGAMS, appKey, appId, searchTerm);
        }
    }
}