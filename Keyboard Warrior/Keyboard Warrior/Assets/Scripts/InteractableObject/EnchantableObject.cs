using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public enum EnchantType
    {
        up,
        down,
        left,
        right,
        idle,
        space,
    }
    public class EnchantableObject : MonoBehaviour
    {
        public EnchantType currentEnchant = EnchantType.idle;
        public virtual void UpEvent() {}
        public virtual void DownEvent() { }
        public virtual void LeftEvent() { }
        public virtual void RightEvent() { }
        public virtual void SpaceEvent() { }
        public virtual void BaseEvent() { }
        public virtual void RetrieveEvent() { }
    }
}
