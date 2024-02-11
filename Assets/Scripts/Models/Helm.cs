using Assets.Scripts.Components;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Helm : MonoBehaviour, IInteractable
    {
        public GameObject Door;

        public void Interact()
        {
            Door.GetComponent<SwitchComponent>().Switch();
        }
    }
}
