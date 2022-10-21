using EcsLiteTest.System;
using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.Main
{
    public class MainEcs
    {
        [Inject] private PlayerInit playerInit;
        [Inject] private DoorButtonInit doorButtonInit;
        [Inject] private Move move;
        [Inject] private PlayerInput playerInput;
        [Inject] private DoorButtonMove doorButtonMove;

        private EcsWorld ecsWorld;
        private IEcsSystems ecsSystems;

        public void Initialize()
        {
            ecsWorld = new EcsWorld();
            ecsSystems = new EcsSystems(ecsWorld)
                .Add(playerInit)
                .Add(move)
                .Add(playerInput)
                .Add(doorButtonInit)
                .Add(doorButtonMove);

            ecsSystems.Init();
        }

        public void UpdateLoop()
        {
            ecsSystems?.Run();
        }

        public void Destroy()
        {
            ecsSystems?.Destroy();
            ecsWorld?.Destroy();
        }
    }
}