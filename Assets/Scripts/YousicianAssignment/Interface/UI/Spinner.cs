using UnityEngine;

namespace YousicianAssignment.Interface.UI
{
    public class Spinner : MonoBehaviour
    {
        [SerializeField]
        protected Animator animator;

        [SerializeField]
        protected string playParam = "Play";

        public void Activate()
        {
            gameObject.SetActive(true);
            animator.SetBool(playParam, true);
        }

        public void Deactivate()
        {
            animator.SetBool(playParam, false);
            gameObject.SetActive(false);
        }

        protected virtual void Awake()
        {
            Deactivate();
        }
        
    }
}