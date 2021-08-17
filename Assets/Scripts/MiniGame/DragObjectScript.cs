using DvmFPS.Observer;
using DvmFPS.UserController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.MiniGame
{
    public class DragObjectScript : MonoBehaviour
    {
        private Vector3 _offset;
        private float mZCoord;
        private Vector2 _currentPosition;
        //public ShotController shotController;
        public PlayerController playerController;
        public ObserverManager observerEventManager;
        public bool onClicked = false;
        [SerializeField] public Camera cam;


        private void Awake()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            observerEventManager = GameObject.Find("ObserverManager").GetComponent<ObserverManager>();
            gameObject.transform.GetComponent<Rigidbody>().useGravity = false;
            
        }


        private void OnMouseDown()
        {
            
        }

        private void OnMouseDrag()
        {


            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.localPosition.z + transform.localPosition.z);

            Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition);

            transform.position = objPosition;
            Debug.Log(mousePosition);

        }

        private void OnMouseUp()
        {
           

            gameObject.transform.GetComponent<Rigidbody>().useGravity = true;
            
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Score"))
            {
                Debug.Log("Sayýýý");
            }
        }

        
    }
}
