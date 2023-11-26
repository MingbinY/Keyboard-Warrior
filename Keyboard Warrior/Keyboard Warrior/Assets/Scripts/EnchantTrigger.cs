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
        public float cooldown = 3f;
        float cooldownTimer = 0f;
        bool inCooldown = false;
        SpriteRenderer sprite;
        private void Start()
        {
            defaultType = enchantType;
            sprite = GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
            if (inCooldown)
            {
                cooldownTimer += Time.deltaTime;
                inCooldown = cooldownTimer >= cooldown ? false : true;
            }
            sprite.enabled = !inCooldown;
        }
        public override void TriggerEvent(GameObject other)
        {
            Debug.Log("TriggerEvent" + " " + enchantType);
            if (inCooldown) { return; }
            inCooldown = true;
            cooldownTimer = 0;
            other.transform.position = transform.position;
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

        public override void ChangeEnchantType(string newType)
        {
            EnchantType newEType = EnchantType.idle;
            switch (newType)
            {
                case "W":
                    newEType = EnchantType.up;
                    break;
                case "A":
                    newEType = EnchantType.left;
                    break;
                case "D":
                    newEType = EnchantType.right;
                    break;
                case "S":
                    newEType = EnchantType.down;
                    break;
                case "Space":
                    newEType = EnchantType.space;
                break;
            }
            enchantType = newEType;
            enchanted = true;
        }
    }
}
