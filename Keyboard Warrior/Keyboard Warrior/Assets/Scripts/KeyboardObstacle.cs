using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace KeyboardWarrior
{
    public class KeyboardObstacle : MonoBehaviour
    {
        GameObject playerObj;
        public GameObject relatedKeyUI;
        private void Start()
        {
            playerObj = PlayerManager.Instance.gameObject;
        }

        private void Update()
        {
            if (Mathf.Abs(playerObj.transform.position.x - transform.position.x) > PlayerManager.Instance.playerDragManager.returnRadius)
            {
                if (relatedKeyUI)
                {
                    relatedKeyUI.SetActive(true);
                    gameObject.SetActive(false);
                    PlayerManager.Instance.playerKeyboardManager.UnuseKey(name);
                }
            }
        }
    }
}
