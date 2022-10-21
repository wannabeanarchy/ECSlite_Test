using EcsLiteTest.Main;
using EcsLiteTest.System;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.Unity
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameMain gameMain;

        public override void InstallBindings()
        {
            Container.Bind<MainEcs>().AsSingle().NonLazy();
            Container.Bind<DoorButtonInit>().AsSingle().NonLazy();
            Container.Bind<DoorButtonMove>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameMain>().FromComponentInHierarchy(gameMain).AsSingle();
        }
    }
}