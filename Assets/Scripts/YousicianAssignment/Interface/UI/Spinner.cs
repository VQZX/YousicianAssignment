using UnityEngine;

namespace YousicianAssignment.Interface.UI
{
    public class Spinner : MonoBehaviour
    {
        [SerializeField]
        protected new Animator animator;

        [SerializeField]
        protected string playParam = "Play";

        public void Activate()
        {
            gameObject.SetActive(true);
            animator.SetBool(playParam, true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            animator.SetBool(playParam, false);
        }

        protected virtual void Awake()
        {
            Deactivate();
        }
        
    }
}