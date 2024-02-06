using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class EnterTriggerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private UnityEvent<GameObject> unityEvent;

        public override void InstallBindings()
        {
            Container.BindInstance(targetGameObject);
            Container.BindInstance(unityEvent);
        }
    }
}