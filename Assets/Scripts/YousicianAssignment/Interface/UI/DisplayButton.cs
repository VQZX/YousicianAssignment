using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    /// <summary>
    /// A button handling input for displaying detail information
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class DisplayButton : MonoBehaviour
    {
        /// <summary>
        /// The attached text component
        /// </summary>
        [SerializeField]
        protected Text text;

        /// <summary>
        /// The attached button component
        /// </summary>
        private Button button;

        /// <summary>
        /// The program info assigned to this button
        /// </summary>
        protected ProgramInfo assignedInfo;
        
        /// <summary>
        /// Activate the button with the assigned info
        /// </summary>
        public void Activate(ProgramInfo info = null)
        {
            SetData(info ?? assignedInfo);
            gameObject.SetActive(true);
            if (button == null)
            {
                button = GetComponent<Button>();
            }
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);  
        }
        
        /// <summary>
        /// Assing the program info and activate the button
        /// </summary>
        /// <param name="info"></param>
        private void SetData(ProgramInfo info)
        {
            if (text == null)
            {
                text = GetComponent<Text>();
            }
            assignedInfo = info;
            text.text = info.ItemTitle;
        }

        /// <summary>
        /// Deactivate the button
        /// </summary>
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnClick()
        {
            UiManager manager;
            if (UiManager.TryGetInstance(out manager))
            {
                manager.DisplayDetails(assignedInfo);
            }
        }
    }
}