using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EcsLiteTest.Unity
{ 
    public class DoorButtonUnity : MonoBehaviour
    {
        public Transform door;
        public Transform button;
        public Vector3 openOffset;
        public float openSpeed;

        public Vector3 DoorCurrentPosition()
        {
            return door.localPosition;
        }

        public void OpenDoor()
        {
            float distance = Vector3.Distance(door.localPosition, openOffset);
            float finalSpeed = (distance / openSpeed);
            door.localPosition = Vector3.Lerp(door.localPosition, openOffset, Time.deltaTime / finalSpeed);
        }
    }
}
