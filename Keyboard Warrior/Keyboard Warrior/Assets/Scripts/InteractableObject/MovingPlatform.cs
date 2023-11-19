using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class MovingPlatform : EnchantableObject
    {
        Rigidbody2D rb;
        public float moveSpeed;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public override void UpEvent()
        {
            Debug.Log("UP");
            currentEnchant = EnchantType.up;
        }
        public override void DownEvent()
        {
            currentEnchant = EnchantType.down;
        }
        public override void LeftEvent()
        {
            Debug.Log("Left");
            currentEnchant = EnchantType.left;
        }
        public override void RightEvent()
        {
            currentEnchant = EnchantType.right;
        }
        public override void BaseEvent()
        {
            currentEnchant = EnchantType.idle;
        }
        public override void SpaceEvent()
        {
            currentEnchant = EnchantType.space;
        }

        private void Update()
        {
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
