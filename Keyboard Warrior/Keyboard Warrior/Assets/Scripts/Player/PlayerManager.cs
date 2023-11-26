using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    #region require components
    [RequireComponent(typeof(InputManager))]
    [RequireComponent(typeof(PlayerAnimationManager))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerKeyboardManager))]
    [RequireComponent(typeof(PlayerLadderMovement))]
    #endregion
    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputManager inputManager;
        public PlayerAnimationManager playerAnimationManager;
        public PlayerMovement playerMovement;
        public PlayerKeyboardManager playerKeyboardManager;
        public PlayerLadderMovement ladderMovement;
        public PlayerHealth playerHealth;
        public PlayerDragManager playerDragManager;
        public PlayerSkillManager playerSkillManager;
        public PlayerEnchantment playerEnchantment;

        protected override void Awake()
        {
            base.Awake();
            inputManager = GetComponent<InputManager>();
            playerAnimationManager = GetComponent<PlayerAnimationManager>();
            playerMovement = GetComponent<PlayerMovement>();
            playerKeyboardManager = GetComponent<PlayerKeyboardManager>();
            ladderMovement = GetComponent<PlayerLadderMovement>();
            playerHealth = GetComponent<PlayerHealth>();
            playerDragManager = GetComponent<PlayerDragManager>();
            playerSkillManager = GetComponent<PlayerSkillManager>();
            playerEnchantment = GetComponent<PlayerEnchantment>();
        }

        private void Start()
        {
            if (GameManager.Instance.respawnPoint != null)
            {
                Instance.gameObject.transform.position = GameManager.Instance.respawnPoint;
            }
            else
            {
                GameManager.Instance.SetSpawnPoint(Instance.transform);
            }
        }
    }
}
