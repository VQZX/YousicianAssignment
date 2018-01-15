using Flusk.Patterns;
using UnityEngine;
using YousicianAssignment.Interface.UI;

namespace YousicianAssignment.Interface
{
    /// <summary>
    /// A management mediator for separating control and UI
    /// </summary>
    public class AppManager : PersistentSingleton<AppManager>
    {
        /// <summary>
        /// The object used to send requests, and recieve data
        /// </summary>
        [SerializeField]
        protected Requestor requestor;

        /// <summary>
        /// The manaager of the UI components
        /// </summary>
        [SerializeField]
        protected UiManager uiManager;

        /// <summary>
        /// Request more data points
        /// </summary>
        public void AppendList()
        {
            requestor.UpdateList();
        }
        
        /// <summary>
        /// Display the recieved information
        /// </summary>
        public void UpdateListDisplay(ProgramInfo [] list)
        {
            uiManager.DisplayList(list);
        }

        /// <summary>
        /// Send a query
        /// </summary>
        public void RequestQuery(string query)
        {
            requestor.Search(query);
        }

        /// <summary>
        /// Initialise the requester
        /// </summary>
        protected virtual void Start()
        {
            requestor.Initialise();
        }
    }
}