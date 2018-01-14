using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YousicianAssignment.Interface.UI;
using YousicianAssignment.Yle;

namespace YousicianAssignment.Interface
{
    public class Requester : MonoBehaviour
    {
        [SerializeField]
        protected int increaseAmount = 10;
        
        private int listLength = 10;
        
        private SearchQueryParser result;

        public void Search(string query)
        {
            listLength = increaseAmount;
            YleManager manager;
            if (YleManager.TryGetInstance(out manager))
            {
                manager.Get(query, OnDataRecieved);
            }
        }

        public void UpdateList()
        {
            ArrayList list = result.GetSubList(listLength);
            List<ProgramInfo> data = new List<ProgramInfo>(listLength);
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                Hashtable hash = (Hashtable) list[i];
                ProgramInfo datum = new ProgramInfo(hash);
                data.Add(datum);
            }

            Mediator mediator;
            if (Mediator.TryGetInstance(out mediator))
            {
                mediator.UpdateListDisplay(data.ToArray());
            }
            listLength += increaseAmount;
        }

        private void OnDataRecieved(SearchQueryParser parser)
        {
            result = parser;
            UpdateList();
        }
    }
}