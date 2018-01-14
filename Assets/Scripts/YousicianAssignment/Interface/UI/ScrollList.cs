using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YousicianAssignment.Utility;

namespace YousicianAssignment.Interface.UI
{
    public class ScrollList : MonoBehaviour
    {
        [SerializeField]
        protected DisplayButton buttonPrefab;

        [SerializeField]
        protected Transform content;

        [SerializeField]
        protected int poolAmount = 50;

        public int CurrentActivatedAmount { get; protected set; }
        
        private DisplayButtonPool pool;
        
        public void Display(ProgramInfo [] list)
        {
            CurrentActivatedAmount = list.Length;
            if (list.Length > pool.PoolAmount)
            {
                pool.Add(list.Length - pool.PoolAmount);
            }
            for (int i = 0; i < CurrentActivatedAmount; i++)
            {
                pool[i].Activate(list[i]);
            }
        }

        protected virtual void Awake()
        {
            pool = new DisplayButtonPool(poolAmount, buttonPrefab, content);
        }

        private void AddButtons(int amount)
        {
            pool.Add(amount);
        }


        private void ResetPool()
        {
            pool.Reset();;
        }
        
        private static void LogNames(ProgramInfo[] list)
        {
            string output = string.Empty;
            foreach (var info in list)
            {
                output = string.Format("{0}\n{1}", output, info.ItemTitle);
            }

            Debug.Log(output);
        }
    }
}
