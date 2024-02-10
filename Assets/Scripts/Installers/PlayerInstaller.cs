using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.MVC.Controllers;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerInputController playerInputController;
        [SerializeField] private PlayerMoveController playerMoveController;
        [SerializeField] private PlayerInteractableController playerInteractableController;
        [SerializeField] private PlayerContactableController playerContactableController;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().FromInstance(_playerModel).AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<PlayerInputController>().FromInstance(playerInputController).AsSingle();
            Container.Bind<PlayerMoveController>().FromInstance(playerMoveController).AsSingle();
            Container.Bind<PlayerInteractableController>().FromInstance(playerInteractableController).AsSingle();
            Container.Bind<PlayerContactableController>().FromInstance(playerContactableController).AsSingle();

        }
    }
}