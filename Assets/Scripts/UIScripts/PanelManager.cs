using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DvmFPS.PanelManage
{
    public class PanelManager : MonoBehaviour
    {

        [SerializeField] public GameObject RestartPanel;
        [SerializeField] public GameObject MiniGamePanel;
        [SerializeField] public GameObject MiniGameStartScore;

        public void OpenPanel(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
        public void ClosePanel(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
        public void IptalPanel()
        {
            MiniGamePanel.SetActive(false);
        }

        public void OpenScore()
        {
            MiniGameStartScore.SetActive(true);
        }
    }
}
