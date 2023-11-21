using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class EnchantTrigger : TriggerEventType
    {
        public EnchantType enchantType = EnchantType.idle;
        public float eventLastTime = 5f;
        public override void TriggerEvent(GameObject other)
        {
            switch (enchantType)
            {
                case EnchantType.up:
                    other.GetComponent<InteractableObject>().upEvent.Invoke();
                 break;
                case EnchantType.down:
                    other.GetComponent<InteractableObject>().downEvent.Invoke();
                 break;
                case EnchantType.left:
                    other.GetComponent<InteractableObject>().leftEvent.Invoke();
                 break;
                case EnchantType.right:
                    other.GetComponent<InteractableObject>().rightEvent.Invoke();
                 break;
                case EnchantType.space:
                    other.GetComponent<InteractableObject>().spaceEvent.Invoke();
                 break;
            }
            StartCoroutine(EventSequence(other));
        }

        protected override IEnumerator EventSequence(GameObject other)
        {
            yield return new WaitForSeconds(eventLastTime);
            other.GetComponent<InteractableObject>().baseEvent.Invoke();
        }
    }
}
