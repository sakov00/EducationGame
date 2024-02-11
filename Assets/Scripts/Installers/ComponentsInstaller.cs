using Assets.Scripts.Components;
using Assets.Scripts.Interfaces;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ComponentsInstaller : MonoInstaller
    {
        [SerializeField] private int interactionRadius;
        [SerializeField] private LayerMask intreactionLayerMask;

        [SerializeField] private UnityEvent<IInteractable> interactableUnityEvent;
        [SerializeField] private UnityEvent<IContactable> contactableUnityEvent;

        public override void InstallBindings()
        {
            Container.BindInstance(interactableUnityEvent);
            Container.BindInstance(contactableUnityEvent);

            Container.BindInstance(interactionRadius);
            Container.BindInstance(intreactionLayerMask);
        }
    }
}