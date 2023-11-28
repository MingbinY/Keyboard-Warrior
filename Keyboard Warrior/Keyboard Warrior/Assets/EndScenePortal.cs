using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KeyboardWarrior
{
    public class EndScenePortal : MonoBehaviour
    {
        public UnityEvent onTriggerEvent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == PlayerManager.Instance.gameObject)
            {
                onTriggerEvent.Invoke();
            }
        }
    }
}
