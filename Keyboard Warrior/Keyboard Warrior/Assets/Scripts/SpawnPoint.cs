using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class SpawnPoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == PlayerManager.Instance.gameObject)
            {
                //Player Enter Spawn Point
                GameManager.Instance.SetSpawnPoint(transform);
            }
        }
    }
}
