using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerDragManager : MonoBehaviour
    {
        public float placeRadius = 5f;
        public float returnRadius = 10f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, placeRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, returnRadius);
        }
    }
}
