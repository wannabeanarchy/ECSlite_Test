using EcsLiteTest.Component;
using EcsLiteTest.Unity;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.System
{
    public class PlayerInit : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var player = ecsWorld.NewEntity();

            ecsWorld.GetPool<Player>()
                .Add(player);

            ecsWorld.GetPool<TargetCoordinate>()
                .Add(player); 
        }
    }
}