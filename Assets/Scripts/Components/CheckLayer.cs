using UnityEngine;

namespace Assets.Scripts.Components
{
    public class CheckLayer : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;

        private Collider2D _collider2D;

        public bool IsTouched;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            IsTouched = _collider2D.IsTouchingLayers(layerMask);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IsTouched = _collider2D.IsTouchingLayers(layerMask);
        }
    }

}