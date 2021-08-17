using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.UserInput
{
    public class InputScripts : MonoBehaviour
    {
        [SerializeField] private ScInputSystem[] _inputDataArray;



        private void Update()
        {
            for (int i = 0; i < _inputDataArray.Length; i++)
            {
                _inputDataArray[i].ProcessInput();
            }
        }
    }
}
