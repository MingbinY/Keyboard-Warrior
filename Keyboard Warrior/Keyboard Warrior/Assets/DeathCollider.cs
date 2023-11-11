using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class DeathCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == PlayerManager.Instance.gameObject)
            {
                GameManager.Instance.Respawn();
            }
        }
    }
}
