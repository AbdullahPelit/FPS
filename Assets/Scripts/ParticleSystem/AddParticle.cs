using DvmFPS.Observer;
using DvmFPS.UserController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.Particle
{
    public class AddParticle : MonoBehaviour
    {
        public PlayerController playerController;
        public ParticleSystem particle;
        ParticleSystem particleTrns;
        [SerializeField] ObserverManager observerManager;

        public void addParticleObject()
        {

            StartCoroutine(EffectiveParticle());
            


        }

        public void ObservParticle()
        {
            if (playerController.isEffective)
            {
                addParticleObject();
            }
            else Debug.Log("sss");
            
        }
        private void OnEnable()
        {
            observerManager.observerEventListen += ObservParticle;
        }
        private void OnDisable()
        {
            observerManager.observerEventListen -= ObservParticle;
        }
        private void OnDestroy()
        {
            observerManager.observerEventListen -= ObservParticle;
        }

        IEnumerator EffectiveParticle()
        {

            particleTrns = Instantiate(particle, playerController.raycastHit.transform.position, Quaternion.identity);
            particleTrns.transform.position = playerController.raycastHit.transform.position;
            particleTrns.Play();
            yield return new WaitForSeconds(2f);
                
            
        }
    }
}
