using EcsLiteTest.Component;
using EcsLiteTest.Unity;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.System
{
    public class PlayerInput : IEcsRunSystem
    {
        [Inject] private IGameMain gameMain;

        public void Run(IEcsSystems systems)
        {
            var _filter = systems.GetWorld().Filter<TargetCoordinate>().End();
            var _entityPool = systems.GetWorld().GetPool<TargetCoordinate>();

            foreach (var entity in _filter)
            {
                ref var _entity = ref _entityPool.Get(entity);
                _entity.targetPoint = gameMain.clickedPosition;
            }
        }
    }
}