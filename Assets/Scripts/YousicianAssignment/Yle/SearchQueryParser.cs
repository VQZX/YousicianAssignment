using System.Collections;

namespace YousicianAssignment.Yle
{
    public class SearchQueryParser : YleJsonParser
    {
        #region Property Names
        private const string ITEM_TITLE = "itemTitle";
        #endregion
        
        
        public SearchQueryParser(string json, bool caseSensitive) : base(json, caseSensitive)
        {
        }

        public ArrayList GetSubList(int length)
        {
            //TODO: check for possible values  ending
            ArrayList list = new ArrayList(length);
            for (int i = 0; i < length; i++)
            {
                list.Add(body[i]);
            }

            return list;
        }
    }
}