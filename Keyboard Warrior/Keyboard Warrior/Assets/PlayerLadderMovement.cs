using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerLadderMovement : MonoBehaviour
    {
        private float vertical;
        private float speed = 1f;
        public bool isLadder;
        private bool isClimbing;

        Rigidbody2D rb;
        float defaultGravity;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            defaultGravity = rb.gravityScale;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Ladder>() != null)
            {
                isLadder = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Ladder>() != null)
            {
                isLadder = false;
                isClimbing = false;
            }
        }

        public void StartClimbing(float yInput)
        {
            vertical = yInput;
            if (isLadder)
            {
                isClimbing = true;
            }
            else
                isClimbing=false;
        }

        private void FixedUpdate()
        {
            if (isClimbing)
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, vertical*speed);
            }
            else
            {
                rb.gravityScale = defaultGravity;
            }
        }
    }
}
