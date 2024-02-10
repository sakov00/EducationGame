using Assets.Scripts.Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Models
{
    public class Hero : MonoBehaviour
    {
        [SerializeField]private int score;
        [SerializeField] private int interactionRadius;
        [SerializeField] private LayerMask intreactionLayerMask;

        private Collider2D[] intreactionResult = new Collider2D[1];

        public void GrabCoins(Coin coin)
        {
            score += (int)coin.TypeCoin;
            ShowScore();
            Destroy(coin.gameObject);
        }

        public void ShowScore()
        {
            Debug.Log(score);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                var size = Physics2D.OverlapCircleNonAlloc(transform.position, interactionRadius, intreactionResult, intreactionLayerMask);

                for (int i = 0; i < size; i++) 
                {
                    var interactableComponent = intreactionResult[i].GetComponent<InteractableComponent>();
                }
            }
        }
    }
}
