using System.Collections.Generic;
using UnityEngine;

namespace YousicianAssignment.Utility
{
    public class MonobehaviourPool<T> where T :  MonoBehaviour
    {
        /// <summary>
        /// The current amount of objects in the pool
        /// </summary>
        public int PoolAmount { get; protected set; }
        
        /// <summary>
        /// The transform of the objects
        /// </summary>
        public Transform Parent { get; protected set; }

        /// <summary>
        /// The template prefab for the objects
        /// </summary>
        public T Prefab { get; protected set; }

        /// <summary>
        /// Direct access to elements within the pool
        /// </summary>
        public T this[int index]
        {
            get { return pool[index]; }
            set { pool[index] = value; }
        }
        
        /// <summary>
        /// The list of pooled objects
        /// </summary>
        protected readonly List<T> pool;
        
        /// <summary>
        /// Create the pool
        /// </summary>
        public MonobehaviourPool(int amount, T prefab, Transform parent)
        {
            PoolAmount = amount;
            Prefab = prefab;
            Parent = parent;
            
            pool = new List<T>();
            for (int i = 0; i < PoolAmount; i++)
            {
                CreateObject();
            }
        }

        /// <summary>
        /// Appends the pool with the amount specified
        /// </summary>
        public virtual void Add(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateObject();
            }
            PoolAmount += amount;
        }
        
        /// <summary>
        /// Creates the object
        /// </summary>
        protected virtual void CreateObject()
        {
            T current = Parent != null ? Object.Instantiate(Prefab, Parent) : Object.Instantiate(Prefab);
            current.gameObject.name = string.Format("{0} {1}", current.gameObject.name, pool.Count);
            pool.Add(current);
        }
    }
}