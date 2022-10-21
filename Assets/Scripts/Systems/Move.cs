using EcsLiteTest.Component;
using EcsLiteTest.Unity;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.System
{
    public class Move : IEcsRunSystem
    {
        [Inject] private IGameMain gameMain;

        public void Run(IEcsSystems systems)
        {
            var _filter = systems.GetWorld().Filter<Player>().Inc<TargetCoordinate>().End();
            var _playerPool = systems.GetWorld().GetPool<Player>();
            var _target = systems.GetWorld().GetPool<TargetCoordinate>();

            foreach (var entity in _filter)
            {
                ref var _player = ref _playerPool.Get(entity);
                ref var _coordinate = ref _target.Get(entity);
                _player.position = gameMain.PlayerPosition();
                gameMain.MoveCamera(_player.position);

                if (_coordinate.targetPoint == Vector3.zero)
                    continue;

                if (_coordinate.targetPoint == gameMain.PlayerPosition())
                {
                    if (_player.moving)
                    {
                        _player.moving = false;
                        gameMain.StopPlayer();
                    }
                    continue;
                }

                gameMain.RotatePlayer(_coordinate.targetPoint);
                gameMain.MovePlayer(_coordinate.targetPoint);

                _player.moving = true;

            }
        }
    }
}