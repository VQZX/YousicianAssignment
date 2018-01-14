﻿namespace YousicianAssignment.Yle
{
    public class YleGet
    {
        private const string SEARCH_PRORGAMS =
            "https://external.api.yle.fi/v1/programs/items.json?q={2}&app_key={0}&app_id={1}";

        private string appId;
        private string appKey;
        
        public YleGet(string appid, string appkey)
        {
            appId = appid;
            appKey = appkey;
        }

        public string CreateSearchProgramsUri(string searchTerm)
        {
            return string.Format(SEARCH_PRORGAMS, appKey, appId, searchTerm);
        }
    }
}