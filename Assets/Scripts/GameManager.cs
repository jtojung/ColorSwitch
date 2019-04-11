using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        public void ResetGame()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        
    }
}