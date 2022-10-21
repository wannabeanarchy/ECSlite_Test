using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcsLiteTest.Unity
{
    public class PlayerUnity : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Animator animator;

        public Vector3 position { get => transform.position; }

        public void RotatePlayer(Vector3 target)
        { 
           transform.LookAt(target); 
        }

        public void MovePlayer(Vector3 target)
        {
            float distance = Vector3.Distance(target, position);
            float finalSpeed = (distance / speed);

            transform.position = Vector3.Lerp(position, target, Time.deltaTime / finalSpeed);

            animator.SetBool("moving", true);
        }

        public void StopPlayer()
        {
            animator.SetBool("moving", false);
        }
    }
}