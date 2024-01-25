using Assets.Scripts.Models;
using UnityEngine;

public class HeroGraber : MonoBehaviour
{
    [SerializeField] private Hero hero;
    public void GrabCoins(Coin coin)
    {
        if (hero is Hero)
        {
            hero.Score += (int)coin.TypeCoin;
            hero.ShowScore();
            Destroy(coin.gameObject);
        }
    }
}
