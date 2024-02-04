using Assets.Scripts.Player.MVC.Controllers;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private PlayerMoveController _playerMoveController;
        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<PlayerMoveController>().FromInstance(_playerMoveController).AsSingle();
            Container.Bind<PlayerInputController>().FromInstance(_playerInputController).AsSingle();
        }
    }
}