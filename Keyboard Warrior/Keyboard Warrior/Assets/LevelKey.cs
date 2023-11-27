using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class LevelKey : MonoBehaviour
    {
        public GameObject doorToOpen;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == PlayerManager.Instance.gameObject)
            {
                //Open Door
                doorToOpen.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
