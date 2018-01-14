using System;
using System.Collections;
using Flusk.Patterns;
using UnityEngine;
using UnityEngine.Networking;

namespace YousicianAssignment.Yle
{
    /// <summary>
    /// A central point for wrapping the Yle API,
    /// Consider adding an abstracting layer for the manager
    /// </summary>
    public class YleManager : PersistentSingleton<YleManager>
    {
        public Action<SearchQueryParser> DataRecieved;
        
        private const string APP_ID = "7912be3f";
        private const string APP_KEY = "e8a9cee4d4b7474898a0b72af7e69c42";

        private YleGet yleGetFormatter;
        
        public void Get(string searchTerm, Action<SearchQueryParser> dataCallback)
        {
            DataRecieved = dataCallback;
            string uri = GenerateSearchTermUri(searchTerm);
            StartCoroutine(GetText(uri));
        }

        protected void Start()
        {
            yleGetFormatter = new YleGet(APP_ID, APP_KEY);
        }
        
        private IEnumerator GetText(string uri)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(uri))
            {
                yield return www.Send();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    // Show results as text
                    if (DataRecieved != null)
                    {
                        SearchQueryParser parser = new SearchQueryParser(www.downloadHandler.text, false);
                        DataRecieved(parser);
                    }
                    DataRecieved = null;
                }
            }
        }

        private string GenerateSearchTermUri(string term)
        {
            return yleGetFormatter.CreateSearchProgramsUri(term);
        }
    }
}