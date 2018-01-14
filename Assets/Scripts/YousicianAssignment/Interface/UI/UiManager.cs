using UnityEngine;

namespace YousicianAssignment.Interface.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        protected ScrollList scrollList;

        [SerializeField]
        protected Submitter submitter;

        [SerializeField]
        protected DetailedDisplay display;

        public void DisplayList(ProgramInfo [] info)
        {
            scrollList.Display(info);
        }
    }
}