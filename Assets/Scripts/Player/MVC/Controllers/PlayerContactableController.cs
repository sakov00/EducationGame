using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerContactableController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerMoveController playerMoveController;

        public void ConcatWithObject(IContactable contactObject)
        {
            if (contactObject is Spike spike)
                ContactWithSpike(spike);
        }

        public void ContactWithSpike(Spike currentSpike)
        {
            playerModel.health -= currentSpike.valueDamage;
            playerMoveController.GetDamage();
        }
    }
}
