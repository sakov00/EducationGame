using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Coin : MonoBehaviour, IInteractable
    {
        [SerializeField] public TypeCoin TypeCoin;

        public void Interact()
        {
            Destroy(gameObject);
        }
    }
}
