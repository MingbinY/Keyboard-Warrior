using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class EnchantableTrigger : EnchantableObject
    {
        EnchantTrigger et;
        private void Start()
        {
            et = GetComponent<EnchantTrigger>();
        }
        public override void BaseEvent()
        {
            base.BaseEvent();
            et.enchantType = et.defaultType;
            ReteriveEnchantment();
        }

        public override void UpEvent()
        {
            base.UpEvent();
            et.enchantType = EnchantType.up;
        }

        public override void DownEvent()
        {
            base.DownEvent();
            et.enchantType = EnchantType.down;
        }

        public override void LeftEvent()
        {
            base.LeftEvent();
            et.enchantType = EnchantType.left;
        }

        public override void RightEvent()
        {
            base.RightEvent();
            et.enchantType = EnchantType.right;
        }
    }
}
