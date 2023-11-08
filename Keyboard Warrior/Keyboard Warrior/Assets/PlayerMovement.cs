using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerMovement : MonoBehaviour
    {
        bool isGrounded = false;
        Rigidbody2D rb;

        [Header("Ground Check")]
        public Vector2 boxSize;
        public float rayDistance;
        public LayerMask groundLayer;

        [Header("Jump Modifier")]
        public float jumpVelocity;

        [Header("Movement Modifier")]
        public float moveSpeed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            isGrounded = GroundCheck();
        }

        #region Ground Check
        bool GroundCheck()
        {
            if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, rayDistance, groundLayer))
                return true;
            else
                return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position - transform.up * rayDistance, boxSize);
        }
        #endregion
        public void HandleMove(Vector2 movementValue)
        {
            
        }

        public void HandleJump()
        {
            rb.velocity = GroundCheck() ? new Vector2(0, jumpVelocity) : rb.velocity;
        }
    }
}
