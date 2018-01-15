using Flusk.Patterns;
using UnityEngine;

namespace YousicianAssignment.Interface.UI
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField]
        protected ScrollList scrollList;

        [SerializeField]
        protected Submitter submitter;

        [SerializeField]
        protected DetailedDisplay display;

        [SerializeField]
        protected Spinner uiSpinner;

        [SerializeField]
        protected int activateDifference = 5;

        public void DisplayList(ProgramInfo [] info)
        {
            scrollList.Display(info);
            uiSpinner.Deactivate();
        }

        public void DisplayDetails(ProgramInfo info)
        {
            display.Display(info);    
        }

        public void ButtonDisplayed(int orderInList)
        {
            bool update = scrollList.CurrentActivatedAmount - orderInList <= activateDifference;
            if (!update)
            {
                return;
            }

            Mediator mediator;
            if (Mediator.TryGetInstance(out mediator))
            {
                mediator.AppendList();   
            }
        }
        
        public void Send(string send)
        {
            Mediator mediator;
            if (Mediator.TryGetInstance(out mediator))
            {
                mediator.RequestQuery(send);   
                uiSpinner.Activate();
            }
        }
    }
}