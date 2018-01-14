using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    public class DetailedDisplay : MonoBehaviour
    {
        [SerializeField]
        protected Text text;

        public void Display(ProgramInfo info)
        {
            text.text = info.ToString();
        }
    }
}