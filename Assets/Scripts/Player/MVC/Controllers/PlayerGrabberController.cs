using Assets.Scripts.Models;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerGrabberController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerView playerView;

        public void GrabCoins(GameObject coin)
        {
            var currentCoin = coin.GetComponent<Coin>();
            playerModel.score += (int)currentCoin.TypeCoin;
            Debug.Log(playerModel.score);
        }
    }
}
