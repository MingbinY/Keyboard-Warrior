using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        Animator animator;
        SpriteRenderer sprite;
        public GameObject playerSprite;
        bool faceLeft = false;

        private void Awake()
        {
            animator = playerSprite.GetComponent<Animator>();
            sprite = playerSprite.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            CheckFaceRight();
            sprite.flipX = faceLeft;
        }

        public void CheckFaceRight()
        {
            Vector2 movementValue = PlayerManager.Instance.inputManager.movementInput;
            if (movementValue == Vector2.zero) return;
            faceLeft = movementValue.x < 0 ? true : false;
        }
    }
}
