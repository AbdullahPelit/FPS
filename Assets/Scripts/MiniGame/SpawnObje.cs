using DvmFPS.ObjectPooling;
using DvmFPS.PanelManage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.MiniGame
{
    public class SpawnObje : MonoBehaviour
    {


        [SerializeField] private ObjectPool objectPool = null;
        [SerializeField] private float spawnInterval = 1f;
        public PanelManager panelManager;

        

        public void SpawnObject()
        {
            panelManager.ClosePanel(panelManager.MiniGamePanel);
            panelManager.OpenScore();
            StartCoroutine(spawnRoutine());
        }

        private IEnumerator spawnRoutine()
        {
            while (true)
            {
                var obj =objectPool.GetObjectPool(0);
                
                //obj.transform.position = Vector3.zero;                
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
