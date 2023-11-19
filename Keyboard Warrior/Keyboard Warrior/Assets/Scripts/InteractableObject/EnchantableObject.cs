using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public enum DirectionType
    {
        up,
        down,
        left,
        right,
        idle
    }
    public class EnchantableObject : MonoBehaviour
    {
        public DirectionType currentDirection;
        public virtual void UpEvent() {}
        public virtual void DownEvent() { }
        public virtual void LeftEvent() { }
        public virtual void RightEvent() { }
        public virtual void BaseEvent() { }
    }
}
