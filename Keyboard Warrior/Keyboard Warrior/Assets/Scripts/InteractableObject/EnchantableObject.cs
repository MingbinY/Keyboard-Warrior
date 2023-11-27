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
        public bool enchanted = false;
        public virtual void OnEnchant(EnchantType enchantType)
        {
            switch (enchantType){
                case EnchantType.up:UpEvent();break;
                case EnchantType.down: DownEvent(); break;
                case EnchantType.left:LeftEvent(); break;
                case EnchantType.right:RightEvent(); break;
            }
        }
        public virtual void UpEvent() { enchanted = true; }
        public virtual void DownEvent() { enchanted = true; }
        public virtual void LeftEvent() { enchanted = true; }
        public virtual void RightEvent() { enchanted = true; }
        public virtual void SpaceEvent() { enchanted = true; }
        public virtual void BaseEvent() { enchanted = false; }
        public virtual void RetrieveEvent() { enchanted = false; }

        public void ReteriveEnchantment()
        {
            PlayerManager.Instance.playerSkillManager.RetrieveEnchantment(currentEnchant);
        }
    }
}
