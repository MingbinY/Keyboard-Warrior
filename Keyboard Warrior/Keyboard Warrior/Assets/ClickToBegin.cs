using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace KeyboardWarrior
{
    public class ClickToBegin : MonoBehaviour
    {
        public GameObject textObject;

        private void Start()
        {
            StartCoroutine(BlinkText());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameSceneManager.Instance.LoadNextScene();
            }
        }

        IEnumerator BlinkText()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                textObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                textObject.SetActive(true);
            }
        }
    }
}
