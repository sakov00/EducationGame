using UnityEngine;

namespace Assets.Scripts.Components
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool state;
        [SerializeField] private string animationKey;

        public void Switch()
        {
            state = !state;
            animator.SetBool(animationKey, state);
        }

        [ContextMenu("Switch")]
        public void SwitchIt()
        {
            Switch();
        }
    }
}
