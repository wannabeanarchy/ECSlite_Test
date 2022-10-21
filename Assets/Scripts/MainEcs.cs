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
        private EcsWorld ecsWorld;
        private IEcsSystems ecsSystems;

        public void Initialize()
        {
            Debug.Log("Initialize ");
            ecsWorld = new EcsWorld();
            ecsSystems = new EcsSystems(ecsWorld);
        }

        public void UpdateECS()
        {
            //Debug.Log("Update ECS " + DateTime.Now);
        }
    }
}