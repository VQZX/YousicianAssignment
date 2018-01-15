using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    public class DetailedDisplay : MonoBehaviour
    {
        /// <summary>
        /// The text to write to
        /// </summary>
        [SerializeField]
        protected Text text;

        /// <summary>
        /// Display the appropriate information
        /// </summary>
        public void Display(ProgramInfo info)
        {
            text.text = info.ToString();
        }

        /// <summary>
        /// Erases the text
        /// </summary>
        public void ResetDisplay()
        {
            text.text = string.Empty;
        }
    }
}