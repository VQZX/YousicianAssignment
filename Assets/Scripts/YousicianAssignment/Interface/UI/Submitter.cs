using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    public class Submitter : MonoBehaviour
    {
        [SerializeField]
        protected Button button;

        [SerializeField]
        protected InputField field;

        [SerializeField]
        protected string dummySubmit;

        [SerializeField]
        protected bool useDummy;

        public void Submit()
        {
            Send(field.text);
        }

        protected virtual void Start()
        {
            if (useDummy)
            {
                Send(dummySubmit);
            }
        }

        private static void Send(string send)
        {
            UiManager manager;
            if (UiManager.TryGetInstance(out manager))
            {
                UiManager.Send(send);
            }
        }
    }
}