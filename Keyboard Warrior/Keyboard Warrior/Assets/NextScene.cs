using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class NextScene : MonoBehaviour
    {
        public void LoadNextScene()
        {
            GameSceneManager.Instance.LoadNextScene();
        }
    }
}
