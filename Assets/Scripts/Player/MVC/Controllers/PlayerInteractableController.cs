using Assets.Scripts.Components;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Player.MVC.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerInteractableController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;

        public void InteractWithObject(IInteractable interactObject)
        {
            if (interactObject is Coin coin)
                GrabCoins(coin);
        }

        public void GrabCoins(Coin coin)
        {
            playerModel.score += (int)coin.TypeCoin;
            Debug.Log(playerModel.score);
        }
    }
}
