using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcsLiteTest.Component
{
    public struct DoorButton
    {
        public Vector3 buttonPosition;
        public int index;
        public bool opened;
    }
}