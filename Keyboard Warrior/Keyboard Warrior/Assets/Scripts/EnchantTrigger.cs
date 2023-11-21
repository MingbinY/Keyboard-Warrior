using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class EnchantTrigger : TriggerEventType
    {
        public EnchantType enchantType = EnchantType.idle;
        EnchantType defaultType;
        public float eventLastTime = 5f;
        public bool enchanted = false;

        private void Start()
        {
            defaultType = enchantType;
        }
        public override void TriggerEvent(GameObject other)
        {
            switch (enchantType)
            {
                case EnchantType.up:
                    other.GetComponent<InteractableObject>().upEvent.Invoke();
                    if (enchanted)
                    {
                        PlayerManager.Instance.playerSkillManager.RetrieveEnchantment("W");
                    }
                 break;
                case EnchantType.down:
                    other.GetComponent<InteractableObject>().downEvent.Invoke();
                    if (enchanted)
                    {
                        PlayerManager.Instance.playerSkillManager.RetrieveEnchantment("S");
                    }
                    break;
                case EnchantType.left:
                    other.GetComponent<InteractableObject>().leftEvent.Invoke();
                    if (enchanted)
                    {
                        PlayerManager.Instance.playerSkillManager.RetrieveEnchantment("A");
                    }
                    break;
                case EnchantType.right:
                    other.GetComponent<InteractableObject>().rightEvent.Invoke();
                    if (enchanted)
                    {
                        PlayerManager.Instance.playerSkillManager.RetrieveEnchantment("D");
                    }
                    break;
                case EnchantType.space:
                    other.GetComponent<InteractableObject>().spaceEvent.Invoke();
                 break;
            }

            if (enchanted)
            {
                enchantType = defaultType;
                enchanted = false;
            }
            StartCoroutine(EventSequence(other));
        }

        protected override IEnumerator EventSequence(GameObject other)
        {
            yield return new WaitForSeconds(eventLastTime);
            other.GetComponent<InteractableObject>().baseEvent.Invoke();
        }

        protected override void ChangeEnchantType(EnchantType newType)
        {
            enchantType = newType;
            enchanted = false;
        }
    }
}
