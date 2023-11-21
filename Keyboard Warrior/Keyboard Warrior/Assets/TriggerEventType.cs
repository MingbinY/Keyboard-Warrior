using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class TriggerEventType : MonoBehaviour
    {
        public virtual void TriggerEvent(GameObject gameObject) { }
        protected virtual IEnumerator EventSequence(GameObject other) { yield return null; }

        public virtual void ChangeEnchantType(string newType)
        {

        }
    }
}
