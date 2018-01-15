using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    public class Submitter : MonoBehaviour
    {
        /// <summary>
        /// The submit button
        /// </summary>
        [SerializeField]
        protected Button button;

        /// <summary>
        /// The text input field
        /// </summary>
        [SerializeField]
        protected InputField field;

        /// <summary>
        /// The keycode for submitting
        /// </summary>
        [SerializeField]
        protected KeyCode submitKey;

        /// <summary>
        /// Subscribe the submission logic to the button
        /// </summary>
        protected virtual void Awake()
        {
            button.onClick.AddListener(Submit);
        }

        /// <summary>
        /// Listen for the key presss and submit the query in the input field
        /// </summary>
        protected virtual void Update()
        {
            bool hit = Input.GetKeyDown(submitKey);
            if (!hit)
            {
                return;
            }
            Submit();
        }
        
        /// <summary>
        /// Submit the input field text
        /// </summary>
        private void Submit()
        {
            Send(field.text);
        }

        /// <summary>
        /// Send the data to the ui manager
        /// </summary>
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