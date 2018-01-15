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
        protected KeyCode submitKey;

        protected virtual void Awake()
        {
            button.onClick.AddListener(Submit);
        }

        protected virtual void Update()
        {
            bool hit = Input.GetKeyDown(submitKey);
            if (!hit)
            {
                return;
            }
            Submit();
        }
        
        private void Submit()
        {
            Send(field.text);
        }

        private static void Send(string send)
        {
            UiManager manager;
            if (UiManager.TryGetInstance(out manager))
            {
                manager.Send(send);
            }
        }
    }
}