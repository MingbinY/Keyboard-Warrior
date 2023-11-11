using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputManager inputManager;
        public PlayerAnimationManager playerAnimationManager;
        public PlayerMovement playerMovement;
        public PlayerEquipmentManager playerEquipmentManager;

        protected override void Awake()
        {
            base.Awake();
            inputManager = GetComponent<InputManager>();
            playerAnimationManager = GetComponent<PlayerAnimationManager>();
            playerMovement = GetComponent<PlayerMovement>();
            playerEquipmentManager = GetComponent<PlayerEquipmentManager>();
        }
    }
}
