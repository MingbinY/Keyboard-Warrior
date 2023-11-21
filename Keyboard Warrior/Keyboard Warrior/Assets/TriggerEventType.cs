using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class TriggerEventType : MonoBehaviour
    {
        public virtual void TriggerEvent(GameObject gameObject) { }
        protected virtual IEnumerator EventSequence(GameObject other) { yield return null; }

        protected virtual void ChangeEnchantType(EnchantType enchantType)
        {

        }
    }
}
