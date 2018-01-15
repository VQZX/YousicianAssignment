using System.Collections;

namespace YousicianAssignment.Yle.Json
{
    public class YleJsonParser
    {
        /// <summary>
        /// The json string
        /// </summary>
        private readonly string data;

        /// <summary>
        /// The hashtable containing the necessary info
        /// </summary>
        protected readonly ArrayList body;

        /// <summary>
        /// The hashtable containing the meta information
        /// </summary>
        private readonly Hashtable meta;

        /// <summary>
        /// The amount of data points available
        /// </summary>
        protected readonly int dataLength;

        /// <summary>
        /// Separates the retrived JSON information into body and meta
        /// </summary>
        protected YleJsonParser(string json, bool caseSensitive)
        {
            data = json;
            var hashtable = SimpleJsonImporter.Import(data, caseSensitive);

            body = (ArrayList)hashtable["data"];
            meta = (Hashtable)hashtable["meta"];
            string dataValue = (string) meta["count"];
            dataLength = int.Parse(dataValue);
        }
    }
}