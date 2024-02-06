using UnityEngine.Events;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class EnterCollisionInstaller : MonoInstaller
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
