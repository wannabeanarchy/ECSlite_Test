using EcsLiteTest.Component;
using EcsLiteTest.Unity;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.System
{
    public class DoorButtonMove : IEcsRunSystem
    {
        [Inject] GameMain gameMain;
        private float radiusActivate = 0.3f;

        public void Run(IEcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<DoorButton>().End();

            var doorButtonPool = systems.GetWorld().GetPool<DoorButton>();

            var playerFilter = systems.GetWorld().Filter<Player>().Inc<TargetCoordinate>().End();
            var playerPool = systems.GetWorld().GetPool<Player>();


            var doorsInfo = gameMain.listDoorButtons;

            foreach (var entityPlayer in playerFilter)
            {
                foreach (var entity in filter)
                {
                    ref var doorButtonComponent = ref doorButtonPool.Get(entity);
                    ref var player = ref playerPool.Get(entityPlayer);

                    if (doorButtonComponent.opened)
                        continue;

                    if (gameMain.listDoorButtons[doorButtonComponent.index].DoorCurrentPosition() == doorButtonComponent.openedPosition)
                    { 
                        doorButtonComponent.opened = true;
                        continue;
                    }

                    if (Vector3.Distance(player.position, doorButtonComponent.buttonPosition) < radiusActivate)
                    {
                        gameMain.listDoorButtons[doorButtonComponent.index].OpenDoor(); 
                    }
                }
            } 
        }
    }
}