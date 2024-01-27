using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Hero : MonoBehaviour
    {
        private static readonly string IsHittedForAnimation = "IsHittedForAnimation";

        [SerializeField]private int score;
        [SerializeField]private int health;
        private Animator animator;


        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

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

        public void GetDamage(int damagePoint)
        {
            health -= damagePoint;
            animator.SetTrigger(IsHittedForAnimation);
            Debug.Log(damagePoint);
        }
    }
}
