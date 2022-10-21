using EcsLiteTest.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EcsLiteTest.Unity
{
    public class GameMain : MonoBehaviour
    {
        [SerializeField] private SceneSettings sceneSettings;

        private MainEcs mainEcs;
        private Vector3 clickedPosition; 

        [Inject]
        void Construct(MainEcs mainEcs)
        {
            this.mainEcs = mainEcs;
        }
        
        void Start()
        {
             mainEcs.Initialize();
        
        }
         
        void Update()
        {
            mainEcs.UpdateECS();
            UpdateInput();
        }

        private void UpdateInput()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = sceneSettings.camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                    clickedPosition = hit.point;

                Debug.Log("clicked " + clickedPosition);
            }
        }
    }
}