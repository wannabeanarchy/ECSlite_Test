using EcsLiteTest.Main;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using Zenject;

namespace EcsLiteTest.Unity
{
    public class GameMain : MonoBehaviour, IGameMain
    {
        [SerializeField] private SceneSettings sceneSettings;
        [SerializeField] private PlayerUnity player;
        [SerializeField] private GameObject ground;
        [SerializeField] public List<DoorButtonUnity> listDoorButtons = new List<DoorButtonUnity>();

        [Inject] private MainEcs mainEcs;

        public Vector3 clickedPosition { get ; set; }

        public void RotatePlayer(Vector3 target) => player.RotatePlayer(target); 
        public void MovePlayer(Vector3 target) => player.MovePlayer(target); 
        public void StopPlayer() => player.StopPlayer(); 
        public Vector3 PlayerPosition() => player.position;
     
        void Start()
        {
             mainEcs.Initialize(); 
        }
         
        void Update()
        {
            mainEcs.UpdateLoop();
            UpdateInput();
        }

        private void UpdateInput()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = sceneSettings.camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == ground)   
                        clickedPosition = hit.point; 
                }
            }
        }

        public void MoveCamera(Vector3 target)
        {
            sceneSettings.cameraTransform.position = new Vector3(target.x + sceneSettings.cameraOffset.x, sceneSettings.cameraOffset.y, target.z + sceneSettings.cameraOffset.z);
        }
    }
}