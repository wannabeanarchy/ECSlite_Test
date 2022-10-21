using EcsLiteTest.System;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.Unity
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInit>().AsSingle().NonLazy();
            Container.Bind<Move>().AsSingle().NonLazy();
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
        }
    }
}