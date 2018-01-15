using Flusk.Patterns;
using UnityEngine;
using YousicianAssignment.Interface.UI;

namespace YousicianAssignment.Interface
{
    /// <summary>
    /// A management mediator for separating control and UI
    /// </summary>
    public class Mediator : PersistentSingleton<Mediator>
    {
        /// <summary>
        /// The 
        /// </summary>
        [SerializeField]
        protected Requestor requestor;

        [SerializeField]
        protected UiManager uiManager;

        public void AppendList()
        {
            requestor.UpdateList();
        }
        
        public void UpdateListDisplay(ProgramInfo [] list)
        {
            uiManager.DisplayList(list);
        }

        public void RequestQuery(string query)
        {
            requestor.Search(query);
        }

        protected virtual void Start()
        {
            requestor.Initialise();
        }
    }
}