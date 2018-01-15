using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YousicianAssignment.Utility;

namespace YousicianAssignment.Interface.UI
{
    public class ScrollList : MonoBehaviour
    {
        /// <summary>
        /// The template of the buttons to display
        /// </summary>
        [SerializeField]
        protected DisplayButton buttonPrefab;

        /// <summary>
        /// The parent of the scrollable items
        /// </summary>
        [SerializeField]
        protected Transform content;

        /// <summary>
        /// The attached scroll rect
        /// </summary>
        [SerializeField]
        protected ScrollRect scrollRect;

        /// <summary>
        /// The size of the pool for all the instantiated items
        /// </summary>
        [SerializeField]
        protected int poolAmount = 50;

        /// <summary>
        /// The current amount of items activated
        /// </summary>
        public int CurrentActivatedAmount { get; protected set; }
        
        /// <summary>
        /// The controller for all the pool items
        /// </summary>
        private DisplayButtonPool pool;
        
        /// <summary>
        /// Display everything in the recived list
        /// </summary>
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

        public void ResetScroll()
        {
            pool.Reset();
            scrollRect.verticalNormalizedPosition = 0;
        }

        /// <summary>
        /// Initialise the pool controller
        /// </summary>
        protected virtual void Awake()
        {
            pool = new DisplayButtonPool(poolAmount, buttonPrefab, content);
        }
    }
}
