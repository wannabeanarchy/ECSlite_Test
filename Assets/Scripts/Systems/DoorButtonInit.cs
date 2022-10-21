using EcsLiteTest.Component;
using EcsLiteTest.Unity;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.System
{
    public class DoorButtonInit : IEcsInitSystem
    {
        [Inject] GameMain gameMain;

        public void Init(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();

            foreach (var door in gameMain.listDoorButtons)
            {
                var doorAndButtonEntity = ecsWorld.NewEntity();

                ecsWorld.GetPool<DoorButton>()
                    .Add(doorAndButtonEntity);

                ecsWorld.GetPool<TargetCoordinate>()
                    .Add(doorAndButtonEntity);

                ref var doorButton = ref ecsWorld.GetPool<DoorButton>().Get(doorAndButtonEntity);

                doorButton.buttonPosition = door.button.position;
                doorButton.index = gameMain.listDoorButtons.IndexOf(door);
            } 
        }
    }
}