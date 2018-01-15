using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using YousicianAssignment.Interface.UI;
using YousicianAssignment.Yle;
using YousicianAssignment.Yle.Json;

namespace YousicianAssignment.Interface
{
    [Serializable]
    public class Requestor
    {
        /// <summary>
        /// The amount to increase the list by when appending
        /// </summary>
        [SerializeField]
        private int increaseAmount = 10;
        
        /// <summary>
        /// The current list length
        /// </summary>
        private int listLength = 10;
        
        /// <summary>
        /// The information that holds the data recieved
        /// </summary>
        private SearchQueryParser result;

        /// <summary>
        /// The manager for interfacing with the API
        /// </summary>
        private YleManager manager;

        public void Initialise()
        {
            if (!YleManager.TryGetInstance(out manager))
            {
                Debug.LogError("No manager present");
            }
        }

        public void Search(string query)
        {
            listLength = increaseAmount;
            manager.Get(query, OnDataRecieved);
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
            manager.DataRecieved -= OnDataRecieved;
        }
    }
}