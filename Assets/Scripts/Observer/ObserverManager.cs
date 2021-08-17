using DvmFPS.UserController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.Observer
{
    public class ObserverManager : MonoBehaviour
    {
        public event ObserverEventListen observerEventListen;
        public event ObserverDragListen observerDragListen;
        public PlayerController playerController;

        private void Update()
        {
            if (observerEventListen != null)
            {
                observerEventListen.Invoke();
            }
            if (observerDragListen != null)
            {
                observerDragListen.Invoke();
            }


        }
    }
}
