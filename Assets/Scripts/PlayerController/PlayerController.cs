using DvmFPS.Observer;
using DvmFPS.PanelManage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.UserController
{
    public class PlayerController : MonoBehaviour
    {
        public ObserverManager observerEventManager;
        public PanelManager panelManager;
        public float range = 15f;
        public Camera fpsCam;
        public bool onActive = false;
        public bool isEffective = false;
        public RaycastHit raycastHit;
        [SerializeField]public Animator anim;
        [SerializeField] public Animator cabinetAnim;
        [SerializeField] public Animator writeBoardAnim;
        private int clickCount = 0;
        private int cabinetClickCount = 0;
        private int boardClickCount = 0;
        private Vector3 atękKutuScale;

        private void Awake()
        {
            panelManager.ClosePanel(panelManager.RestartPanel);
            panelManager.ClosePanel(panelManager.MiniGamePanel);
            panelManager.ClosePanel(panelManager.MiniGameStartScore);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                onActive = true;
                if (isEffective)
                {
                    objectEvent();
                    if (raycastHit.transform.name == "Manken")
                    {
                        clickCount++;
                        if (clickCount > 4)
                        {
                            clickCount = 0;
                        }
                    }
                    else if (raycastHit.transform.name == "cabinet")
                    {
                        cabinetClickCount++;
                        if (cabinetClickCount > 2)
                        {
                            cabinetClickCount = 1;
                        }

                    }
                    else if (raycastHit.transform.name == "writing_board")
                    {
                        boardClickCount++;
                        if (boardClickCount > 2)
                        {
                            boardClickCount = 1;
                        }
                    }
                    else if (raycastHit.transform.name == "Sphere")
                    {
                        var offset = new Vector3(3,3,3);
                        raycastHit.transform.position = gameObject.transform.position + offset;
                    }
                }
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                onActive = false;
            }
            
        }

        private void OnEnable()
        {
            observerEventManager.observerEventListen += ObserverListen;
        }
        private void OnDisable()
        {
            observerEventManager.observerEventListen -= ObserverListen;
        }
        private void OnDestroy()
        {
            observerEventManager.observerEventListen -= ObserverListen;
        }

        private void ObserverListen()
        {
            Detected();
        }
        public void Detected()
        {

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out raycastHit, range))
            {

                Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.black);

                
                if (raycastHit.transform.CompareTag("EffectiveObj"))
                {
                    //Particle Ve UI çęksęn
                    Debug.Log("Etkilețimli Obje");
                    isEffective = true;
                    if (raycastHit.transform.name == "trash_can" && isEffective)
                    {
                        // 1.5 katę scale olan bir animasyonda yaptęm. Fakat tam olarak ne istendiđini bilmediđim için böyle bęraktęm.     
                        
                        atękKutuScale = raycastHit.transform.localScale;
                        atękKutuScale.Set(0.015f, 0.015f, 0.015f);
                        raycastHit.transform.localScale = atękKutuScale;

                    }

                }
                else if (!raycastHit.transform.CompareTag("EffectiveObj"))
                {
                    isEffective = false;

                }

            }

        }
        

        public void objectEvent()
        {
            if (raycastHit.transform.name == "desk_lamp" && isEffective)
            {


                if (raycastHit.transform.Find("Point light").GetComponent<Light>().intensity != 0)
                {
                    
                    raycastHit.transform.Find("Point light").GetComponent<Light>().intensity = 0;
                }
                else raycastHit.transform.Find("Point light").GetComponent<Light>().intensity = 1;
            }
            else if (raycastHit.transform.name == "door_01" || raycastHit.transform.name == "door_02" && isEffective)
            {
                panelManager.OpenPanel(panelManager.RestartPanel);
                //Restart
            }
            else if (raycastHit.transform.name == "writing_board" && isEffective)
            {
                //Rotate sadece coliderę dönderiyor obje dönmüyor assette bir sorun var sanęręm. Bu yüzden animasyonla çözdüm bazę durumlarę
                writeBoardAnim.SetInteger("WriteBoardClick", boardClickCount);
                
                
            }
            else if (raycastHit.transform.name == "trash_can" && isEffective)
            {
                panelManager.OpenPanel(panelManager.MiniGamePanel);
                   
                
            }
            else if (raycastHit.transform.name == "cabinet" && isEffective)
            {
                cabinetAnim.SetInteger("CabinetClick", cabinetClickCount);
            }
            else if (raycastHit.transform.name == "Manken" && isEffective)
            {
                anim.SetInteger("Index", clickCount);
            }

            else
            {
                Detected();
                
            }
                
        }
       


    }
}
