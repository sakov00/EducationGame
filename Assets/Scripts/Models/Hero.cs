using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Hero : MonoBehaviour
    {
        [SerializeField]private int score;

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
    }
}
