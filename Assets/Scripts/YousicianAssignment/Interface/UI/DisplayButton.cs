using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    [RequireComponent(typeof(Button))]
    public class DisplayButton : MonoBehaviour
    {
        [SerializeField]
        protected Text text;

        private Button button;

        private RectTransform mask;

        private RectTransform rectTransform;

        public bool Active
        {
            get { return gameObject.activeSelf; }
        }

        private int orderInList;

        protected ProgramInfo assignedInfo;
        
        public void SetData(ProgramInfo info)
        {
            if (text == null)
            {
                text = GetComponent<Text>();
            }
            assignedInfo = info;
            text.text = info.ItemTitle;
        }

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
            orderInList = transform.GetSiblingIndex();
            if (mask == null)
            {
                mask = (RectTransform)GetComponentInParent<Mask>().transform;
            }

            if (rectTransform == null)
            {
                rectTransform = (RectTransform) transform;
            }
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        protected virtual void Update()
        {
            if (!mask.rect.Contains(rectTransform.position))
            {
                return;
            }

            UiManager manager;
            if (UiManager.TryGetInstance(out manager))
            {
                manager.ButtonDisplayed(orderInList);
            }
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