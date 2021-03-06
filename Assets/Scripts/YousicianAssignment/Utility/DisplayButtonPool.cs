﻿using System;
using UnityEngine;
using YousicianAssignment.Interface.UI;
using Object = UnityEngine.Object;

namespace YousicianAssignment.Utility
{
    public class DisplayButtonPool : MonobehaviourPool<DisplayButton>
    {

        public DisplayButtonPool(int amount, DisplayButton prefab, Transform parent) : base(amount, prefab, parent)
        {
        }
        
        /// <summary>
        /// Creates the object, and deactivates by default
        /// </summary>
        protected override void CreateObject()
        {
            DisplayButton current = Object.Instantiate(Prefab, Parent);
            current.gameObject.name = string.Format("{0} {1}", current.gameObject.name, pool.Count);
            current.Deactivate();
            pool.Add(current);
        }

        /// <summary>
        /// Deactivates all the objects in the pool
        /// </summary>
        public virtual void Reset()
        {
            foreach (var current in pool)
            {
                current.Deactivate();
            }
        }
    }
}