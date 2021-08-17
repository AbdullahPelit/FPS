using DvmFPS.UserInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.UserController
{
    public class PlayerMovementController : MonoBehaviour
    {
        public CharacterController controller;
        [SerializeField] private ScInputSystem _scInpuMovementtSystem;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;

        private void Update()
        {
            Vector3 move = transform.right * _scInpuMovementtSystem.Vertical + transform.forward * _scInpuMovementtSystem.Horizontal;

            controller.Move(move * _playerMovementSettings.HorizontalSpeed);
        }
    }
}
