using System.Collections;

namespace YousicianAssignment.Yle.Json
{
    public class YleJsonParser
    {
        /// <summary>
        /// The hashtable containing the necessary info
        /// </summary>
        protected readonly ArrayList body;

        /// <summary>
        /// The amount of data points available
        /// </summary>
        protected readonly int dataLength;

        /// <summary>
        /// Separates the retrived JSON information into body and meta
        /// </summary>
        protected YleJsonParser(string json, bool caseSensitive)
        {
            var hashtable = SimpleJsonImporter.Import(json, caseSensitive);

            body = (ArrayList)hashtable["data"];
            dataLength = body.Count;
        }
    }
}