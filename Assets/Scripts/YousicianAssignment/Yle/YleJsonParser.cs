using System.Collections;

namespace YousicianAssignment.Yle
{
    public class YleJsonParser
    {
        /// <summary>
        /// The json string
        /// </summary>
        public string Data { get; protected set; }
        
        /// <summary>
        /// The hashtable containing all the information
        /// </summary>
        protected Hashtable hashtable;

        /// <summary>
        /// The hashtable containing the necessary info
        /// </summary>
        protected ArrayList body;

        /// <summary>
        /// The hashtable containing the meta information
        /// </summary>
        protected Hashtable meta;
        
        
        public YleJsonParser(string json, bool caseSensitive)
        {
            Data = json;
            hashtable = SimpleJsonImporter.Import(Data, caseSensitive);

            body = (ArrayList)hashtable["data"];
            meta = (Hashtable)hashtable["meta"];
        }
    }
}