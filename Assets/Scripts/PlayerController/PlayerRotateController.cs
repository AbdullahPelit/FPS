using DvmFPS.UserInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.UserController
{
    public class PlayerRotateController : MonoBehaviour
    {
        public Transform playerBody;
        [SerializeField] private ScInputSystem _scInpuRotatetSystem;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        private float yRotation;
        private void Update()
        {
            yRotation -= (_scInpuRotatetSystem.Vertical * _playerMovementSettings.MouseYSpeed);
            yRotation = Mathf.Clamp(yRotation,-45f,45f);
            transform.localRotation = Quaternion.Euler(yRotation,0f,0f);

            playerBody.Rotate(Vector3.up * _scInpuRotatetSystem.Horizontal * _playerMovementSettings.MouseXSpeed  );

            
            
        }
    }
}
