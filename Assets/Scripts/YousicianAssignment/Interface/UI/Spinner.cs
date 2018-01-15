using UnityEngine;

namespace YousicianAssignment.Interface.UI
{
    public class Spinner : MonoBehaviour
    {
        /// <summary>
        /// The attached animation
        /// </summary>
        [SerializeField]
        protected Animator animator;

        /// <summary>
        /// The parameter used to active the animation
        /// </summary>
        [SerializeField]
        protected string playParam = "Play";

        /// <summary>
        /// Activates the game object and the animation
        /// </summary>
        public void Activate()
        {
            gameObject.SetActive(true);
            animator.SetBool(playParam, true);
        }

        /// <summary>
        /// Deactivates the game object and the animation
        /// </summary>
        public void Deactivate()
        {
            animator.SetBool(playParam, false);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Deactivate on start
        /// </summary>
        protected virtual void Awake()
        {
            Deactivate();
        }
        
    }
}