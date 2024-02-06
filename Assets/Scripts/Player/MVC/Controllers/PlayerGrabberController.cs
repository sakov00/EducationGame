using Assets.Scripts.Models;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerGrabberController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerView playerView;

        public void GrabCoins(Coin coin)
        {
            playerModel.score += (int)coin.TypeCoin;
            Debug.Log(playerModel.score);
        }
    }
}
