using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KeyboardWarrior
{
    public class GameSceneManager : Singleton<GameSceneManager>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextScene()
        {
            int targetIndex = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(targetIndex);
            SceneManager.LoadScene(targetIndex);
        }

        public void LoadTargetScene(int targetIndex)
        {
            if (targetIndex < SceneManager.sceneCount) 
            { 
                SceneManager.LoadScene(targetIndex);
            }
        }
    }
}
