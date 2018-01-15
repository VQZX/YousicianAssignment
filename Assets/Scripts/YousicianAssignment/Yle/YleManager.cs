using System;
using System.Collections;
using Flusk.Patterns;
using UnityEngine;
using UnityEngine.Networking;
using YousicianAssignment.Yle.Json;

namespace YousicianAssignment.Yle
{
    /// <summary>
    /// A central point for wrapping the Yle API,
    /// TODO: Consider adding an abstract layer for the manager
    /// </summary>
    public class YleManager : PersistentSingleton<YleManager>
    {
        /// <summary>
        /// The maximum amount of results recievable
        /// </summary>
        [SerializeField]
        protected int maxResults = 100;
        
        /// <summary>
        /// The broacast event for when the data has been recived
        /// </summary>
        public event Action<SearchQueryParser> DataRecieved;
        
        /// <summary>
        /// The Unique APP_ID for interfacing with the API
        /// </summary>
        private const string APP_ID = "7912be3f";
        
        /// <summary>
        /// The App key for interfacing with the API
        /// </summary>
        private const string APP_KEY = "e8a9cee4d4b7474898a0b72af7e69c42";

        /// <summary>
        /// Query formatter
        /// </summary>
        private YleApiQueryFormatter yleApiQueryFormatterFormatter;
        
        /// <summary>
        /// Exposed method for searching the API
        /// </summary>
        public void Get(string searchTerm, Action<SearchQueryParser> dataCallback)
        {
            DataRecieved = dataCallback;
            string uri = yleApiQueryFormatterFormatter.CreateSearchProgramsUri(searchTerm);
            StartCoroutine(GetText(uri));
        }

        /// <summary>
        /// Initalise the query formatter
        /// </summary>
        protected void Start()
        {
            yleApiQueryFormatterFormatter = new YleApiQueryFormatter(APP_ID, APP_KEY, maxResults);
        }
            
        /// <summary>
        /// The poll to the API to retrieve the data
        /// </summary>
        private IEnumerator GetText(string uri)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(uri))
            {
                yield return www.Send();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.LogError(www.error);
                }
                else
                {
                    if (DataRecieved == null)
                    {
                        yield break;
                    }
                    // Broadcast results
                    SearchQueryParser parser = new SearchQueryParser(www.downloadHandler.text, false);
                    DataRecieved(parser);
                }
            }
        }
    }
}