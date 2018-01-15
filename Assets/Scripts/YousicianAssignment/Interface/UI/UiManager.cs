using Flusk.Patterns;
using UnityEngine;

namespace YousicianAssignment.Interface.UI
{
    public class UiManager : Singleton<UiManager>
    {
        /// <summary>
        /// The scroll list for display the recieved data list in summary
        /// </summary>
        [SerializeField]
        protected ScrollList scrollList;

        /// <summary>
        /// The text display controller for the individual recived items
        /// </summary>
        [SerializeField]
        protected DetailedDisplay display;

        /// <summary>
        /// The UI spinner for when we are wating to recieve the requested data
        /// </summary>
        [SerializeField]
        protected Spinner uiSpinner;

        /// <summary>
        /// The difference between the most recently viewed button
        /// the bottom of the button list for requesting more data
        /// </summary>
        [SerializeField]
        protected int activateDifference = 5;

        /// <summary>
        /// Displays the revieved info in a list
        /// </summary>
        public void DisplayList(ProgramInfo [] info)
        {
            scrollList.Display(info);
            uiSpinner.Deactivate();
        }

        /// <summary>
        /// Dispalays the details concerning a selected item
        /// </summary>
        public void DisplayDetails(ProgramInfo info)
        {
            display.Display(info);    
        }

        /// <summary>
        /// Called by the buttons when they on the threshold of displaying
        /// </summary>
        public void ButtonDisplayed(int orderInList)
        {
            bool update = scrollList.CurrentActivatedAmount - orderInList <= activateDifference;
            if (!update)
            {
                return;
            }

            AppManager appManager;
            if (AppManager.TryGetInstance(out appManager))
            {
                appManager.AppendList();   
            }
        }
        
        /// <summary>
        /// Sends a query to app manager for sending to the API
        /// </summary>
        public void Send(string send)
        {
            AppManager appManager;
            if (AppManager.TryGetInstance(out appManager))
            {
                appManager.RequestQuery(send);   
                uiSpinner.Activate();
            }
        }
    }
}