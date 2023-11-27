using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class EnchantTrigger : TriggerEventType
    {
        public EnchantType enchantType = EnchantType.idle;
        public EnchantType defaultType;
        public float eventLastTime = 5f;
        public bool enchanted = false;
        public float cooldown = 3f;
        float cooldownTimer = 0f;
        bool inCooldown = false;
        SpriteRenderer sprite;
        private void Start()
        {
            enchantType = defaultType;
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
            InteractableObject io = other.GetComponent<InteractableObject>();
            if (io)
            {
                io.OnEnchant(enchantType);
            }
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
