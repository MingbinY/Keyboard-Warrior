using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerHealth : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<DeathCollider>() != null)
            {
                GameManager.Instance.Respawn();
            }
        }
    }
}
