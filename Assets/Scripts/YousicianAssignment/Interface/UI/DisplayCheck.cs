using UnityEngine;
using UnityEngine.UI;

namespace YousicianAssignment.Interface.UI
{
    /// <summary>
    /// Handles broadcasting of information when object is viewed
    /// in a scroll view
    /// </summary>
    public class DisplayCheck : MonoBehaviour
    {
        /// <summary>
        /// The mask component within the scroll list
        /// </summary>
        private RectTransform mask;

        /// <summary>
        /// The attached RectTransform
        /// </summary>
        private RectTransform rectTransform;
        
        /// <summary>
        /// The order within the list of transforms
        /// </summary>
        private int orderInList;

        /// <summary>
        /// Cache the necessary information
        /// </summary>
        protected virtual void Awake()
        {
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
        
        /// <summary>
        /// Check if the button is over the threshold
        /// </summary>
        protected virtual void Update()
        {
            Rect rect = rectTransform.rect;
            rect.position += (Vector2)rectTransform.position;
            Rect maskRect = mask.rect;
            maskRect.position += (Vector2)mask.position;
            // Is the button on the threshold
            if (rect.yMax > maskRect.yMin && rect.yMin < maskRect.yMin )
            {
                ButtonDisplayed();
            }
        }

        /// <summary>
        /// Informs the UI manger that this button has been displayed
        /// </summary>
        private void ButtonDisplayed()
        {
            UiManager manager;
            if (UiManager.TryGetInstance(out manager))
            {
                manager.ButtonDisplayed(orderInList);
            }
        }
    }
}