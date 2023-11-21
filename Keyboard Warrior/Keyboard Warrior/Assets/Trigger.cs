using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KeyboardWarrior
{
    public class Trigger : MonoBehaviour
    {
        public UnityEvent<GameObject> triggerEvent;
        public bool destroyAfterTrigger = false;

        private void Start()
        {
            if (GetComponent<TriggerEventType>())
                triggerEvent.AddListener(GetComponent<TriggerEventType>().TriggerEvent);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<InteractableObject>()) return;
            if (triggerEvent != null)
            {
                triggerEvent.Invoke(other.gameObject);
                if (destroyAfterTrigger )
                {
                    GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
}
