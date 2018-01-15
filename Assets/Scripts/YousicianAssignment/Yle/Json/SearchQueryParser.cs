using System.Collections;
using UnityEngine;

namespace YousicianAssignment.Yle.Json
{
    public class SearchQueryParser : YleJsonParser
    {
        public SearchQueryParser(string json, bool caseSensitive) : base(json, caseSensitive)
        {
        }

        public ArrayList GetSubList(int length)
        {
            ArrayList list = new ArrayList(length);
            int min = Mathf.Min(length, dataLength);
            for (int i = 0; i < min; i++)
            {
                list.Add(body[i]);
            }
            return list;
        }
    }
}