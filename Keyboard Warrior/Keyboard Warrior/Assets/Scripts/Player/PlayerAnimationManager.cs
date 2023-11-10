using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        Animator animator;
        SpriteRenderer sprite;
        InputManager playerInput;
        PlayerMovement playerMovement;
        public GameObject playerSprite;
        bool faceLeft = false;

        private void Awake()
        {
            animator = playerSprite.GetComponent<Animator>();
            sprite = playerSprite.GetComponent<SpriteRenderer>();
            
        }
        private void Start()
        {
            playerInput = PlayerManager.Instance.inputManager;
            playerMovement = PlayerManager.Instance.playerMovement;
        }

        private void Update()
        {
            CheckFaceRight();
            sprite.flipX = faceLeft;
            animator.SetFloat("xSpeed", Mathf.Abs(playerInput.movementInput.x));
            animator.SetBool("isGrounded", playerMovement.isGrounded);
        }

        public void CheckFaceRight()
        {
            Vector2 movementValue = playerInput.movementInput;
            if (movementValue == Vector2.zero) return;
            faceLeft = movementValue.x < 0 ? true : false;
        }
    }
}
