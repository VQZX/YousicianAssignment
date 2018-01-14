namespace Yle
{
    public class YleGet
    {
        private const string SEARCH_PRORGAMS =
            "https://external.api.yle.fi/v1/programs/items.json?q={2}&limit=1&app_key={0}&app_id={1}YOUR_APP_ID";

        private string appId;
        private string appKey;
        
        public YleGet(string appid, string appkey)
        {
            appId = appid;
            appKey = appkey;
        }

        public string CreateSearchProgramsUri(string searchTerm)
        {
            return string.Format(SEARCH_PRORGAMS, appId, appKey, searchTerm);
        }
    }
}