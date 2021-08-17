using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.ObjectPooling
{
    public class ObjectPool : MonoBehaviour
    {
        [System.Serializable]
        public struct Pool
        {
            public Queue<GameObject> pooledObject;
            public GameObject objectPrefabs;
            public int poolSize;
        }

        [SerializeField] private Pool[] pools;
        [SerializeField] private Transform[] points;


        private void Awake()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].pooledObject = new Queue<GameObject>();
                Debug.Log(j + " pool length");
                for (int k = 0; k < points.Length ; k++)
                {
                    Debug.Log(k + " point length");
                    for (int i = 0; i < pools[j].poolSize; i++)
                    {
                        Debug.Log(i + " instantiate length");
                        GameObject obj = Instantiate(pools[j].objectPrefabs, points[k].transform);
                        
                        obj.transform.position = points[k].transform.position;
                        obj.transform.parent = points[k].transform;
                        obj.SetActive(false);

                        pools[j].pooledObject.Enqueue(obj);
                    }
                }

               
            }
        }

        public GameObject GetObjectPool(int ObjectType)
        {
            if (ObjectType >= pools.Length)
            {
                return null;
            }


            GameObject obj = pools[ObjectType].pooledObject.Dequeue();
            obj.SetActive(true);

            pools[ObjectType].pooledObject.Enqueue(obj);

            return obj;

        }
    }
}
