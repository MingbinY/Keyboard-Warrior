using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    #region require components
    [RequireComponent(typeof(InputManager))]
    [RequireComponent(typeof(PlayerAnimationManager))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerEquipmentManager))]
    [RequireComponent(typeof(PlayerKeyboardManager))]
    [RequireComponent(typeof(PlayerLadderMovement))]
    #endregion
    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputManager inputManager;
        public PlayerAnimationManager playerAnimationManager;
        public PlayerMovement playerMovement;
        public PlayerEquipmentManager playerEquipmentManager;
        public PlayerKeyboardManager playerKeyboardManager;
        public PlayerLadderMovement ladderMovement;

        protected override void Awake()
        {
            base.Awake();
            inputManager = GetComponent<InputManager>();
            playerAnimationManager = GetComponent<PlayerAnimationManager>();
            playerMovement = GetComponent<PlayerMovement>();
            playerEquipmentManager = GetComponent<PlayerEquipmentManager>();
            playerKeyboardManager = GetComponent<PlayerKeyboardManager>();
            ladderMovement = GetComponent<PlayerLadderMovement>();
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
