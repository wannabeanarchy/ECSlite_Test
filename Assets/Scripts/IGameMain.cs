using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EcsLiteTest.Unity
{
    interface IGameMain
    {
        Vector3 clickedPosition { get; set; }
        void RotatePlayer(Vector3 target);
        void MovePlayer(Vector3 target);
        Vector3 PlayerPosition();
        void StopPlayer();
        void MoveCamera(Vector3 target);
    }
}
