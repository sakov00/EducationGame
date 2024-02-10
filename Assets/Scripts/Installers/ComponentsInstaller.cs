using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ComponentsInstaller : MonoInstaller
    {
        [SerializeField] private UnityEvent<IInteractable> interactableUnityEvent;
        [SerializeField] private UnityEvent<IContactable> contactableUnityEvent;

        public override void InstallBindings()
        {
            Container.BindInstance(interactableUnityEvent);
            Container.BindInstance(contactableUnityEvent);
        }
    }
}