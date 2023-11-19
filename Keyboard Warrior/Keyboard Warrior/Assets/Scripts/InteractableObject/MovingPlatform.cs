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
            currentDirection = DirectionType.up;
        }
        public override void DownEvent()
        {
            currentDirection = DirectionType.down;
        }
        public override void LeftEvent()
        {
            Debug.Log("Left");
            currentDirection = DirectionType.left;
        }
        public override void RightEvent()
        {
            currentDirection = DirectionType.right;
        }
        public override void BaseEvent()
        {
            currentDirection = DirectionType.idle;
        }

        private void Update()
        {
            Vector2 velocity = Vector2.zero;
            switch (currentDirection)
            {
                case DirectionType.up:
                    velocity.y = 1;
                    break;
                case DirectionType.down:
                    velocity.y = -1;
                    break;
                case DirectionType.left:
                    velocity.x = -1;
                    break;
                case DirectionType.right:
                    velocity.x = 1;
                    break;
                default:
                    velocity = Vector2.zero;
                    break;
            }
            rb.velocity = velocity * moveSpeed;
        }
    }
}
