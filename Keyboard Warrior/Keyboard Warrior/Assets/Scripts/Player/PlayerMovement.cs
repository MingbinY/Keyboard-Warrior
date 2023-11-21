using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool isGrounded = false;
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
            HandleMove(PlayerManager.Instance.inputManager.movementInput);
            HandleJump(PlayerManager.Instance.inputManager.jumpInput);
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
        #region Handle Movement
        public void HandleMove(Vector2 movementValue)
        {
            if (PlayerManager.Instance.playerEnchantment.enchanted) return;
            if (movementValue.x < 0 && !PlayerManager.Instance.playerKeyboardManager.canUseA) movementValue.x = 0;
            if (movementValue.x > 0 && !PlayerManager.Instance.playerKeyboardManager.canUseD) movementValue.x = 0;
            rb.velocity = new Vector2(movementValue.x * moveSpeed, movementValue.y + rb.velocity.y);
            //rb.MovePosition(rb.position + movementValue * Time.deltaTime);
        }

        public void HandleJump(bool jumpInput)
        {
            if (!jumpInput || !PlayerManager.Instance.playerKeyboardManager.canUseSpace) return;
            rb.velocity = GroundCheck() ? new Vector2(0, jumpVelocity) : rb.velocity;
        }
        #endregion
    }
}
