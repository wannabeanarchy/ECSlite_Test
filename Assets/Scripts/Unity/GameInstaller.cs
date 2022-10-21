using EcsLiteTest.Main;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.Unity
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MainEcs>().AsSingle().NonLazy(); 
        }
    }
}