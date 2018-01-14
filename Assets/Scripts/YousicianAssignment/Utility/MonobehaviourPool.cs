using System.Collections.Generic;
using UnityEngine;

namespace YousicianAssignment.Utility
{
    public class MonobehaviourPool<T> where T :  MonoBehaviour
    {
        public int PoolAmount { get; protected set; }
        
        public Transform Parent { get; protected set; }

        public T Prefab { get; protected set; }

        public T this[int index]
        {
            get { return pool[index]; }
            set { pool[index] = value; }
        }
        
        protected List<T> pool;
        
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

        protected virtual void CreateObject()
        {
            T current = Object.Instantiate(Prefab, Parent);
            pool.Add(current);
        }

        public virtual void Add(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateObject();
            }
            PoolAmount += amount;
        }
    }
}