using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class Word : MonoBehaviour
    {
        private void Update()
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, transform.right, 100.0F);
            Debug.Log(hits);
        }
    }
}
