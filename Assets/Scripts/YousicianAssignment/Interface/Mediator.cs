using Flusk.Patterns;
using UnityEngine;
using YousicianAssignment.Interface.UI;

namespace YousicianAssignment.Interface
{
    public class Mediator : PersistentSingleton<Mediator>
    {
        [SerializeField]
        protected Requester requester;

        [SerializeField]
        protected UiManager uiManager;

        public void UpdateList()
        {
            requester.UpdateList();;
        }
        
        public void UpdateListDisplay(ProgramInfo [] list)
        {
            uiManager.DisplayList(list);
        }
    }
}