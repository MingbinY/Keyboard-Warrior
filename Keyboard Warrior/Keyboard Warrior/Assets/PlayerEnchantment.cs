using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerEnchantment : EnchantableObject
    {
        Rigidbody2D rb;
        public float moveSpeed;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public override void UpEvent()
        {
            currentEnchant = EnchantType.up;
            enchanted = true;
        }
        public override void DownEvent()
        {
            currentEnchant = EnchantType.down;
            enchanted = true;
        }
        public override void LeftEvent()
        {
            currentEnchant = EnchantType.left;
            enchanted = true;
        }
        public override void RightEvent()
        {
            currentEnchant = EnchantType.right;
            enchanted = true;
        }
        public override void BaseEvent()
        {
            Debug.Log("Player Base Event");
            currentEnchant = EnchantType.idle;
            rb.gravityScale = 1;
            enchanted = false;
        }
        public override void SpaceEvent()
        {
            currentEnchant = EnchantType.space;
            enchanted = true;
        }

        private void Update()
        {
            rb.gravityScale = enchanted ? 0 : 1;

            Vector2 velocity = Vector2.zero;
            Vector2 scale = Vector2.one;
            switch (currentEnchant)
            {
                case EnchantType.up:
                    velocity.y = 1;
                    break;
                case EnchantType.down:
                    velocity.y = -1;
                    break;
                case EnchantType.left:
                    velocity.x = -1;
                    break;
                case EnchantType.right:
                    velocity.x = 1;
                    break;
                case EnchantType.space:
                    scale = Vector2.one * 2;
                    break;
                default:
                    velocity = Vector2.zero;
                    break;
            }
            rb.velocity = velocity * moveSpeed;
            transform.localScale = scale;
        }
    }
}
