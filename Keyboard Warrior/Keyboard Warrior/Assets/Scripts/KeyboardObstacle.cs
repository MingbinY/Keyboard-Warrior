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
        public string obstacleName;
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
                    PlayerManager.Instance.playerSkillManager.RetrieveObstacle(this);
                }
            }
        }
    }
}
