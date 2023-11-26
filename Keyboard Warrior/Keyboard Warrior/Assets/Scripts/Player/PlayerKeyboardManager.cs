using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace KeyboardWarrior
{
    public class PlayerKeyboardManager : MonoBehaviour
    {
        InputManager inputManager;
        public bool canUseW = true;
        public bool canUseA = true;
        public bool canUseS = true;
        public bool canUseD = true;
        public bool canUseSpace = true;

        public bool pressedW = false;
        public bool pressedA = false;
        public bool pressedS = false;
        public bool pressedD = false;
        public bool pressedSpace = false;

        float retrieveTimer = 0;
        public float retrieveTime = 5f;
        bool activatedRetrieve = false;

        private void Start()
        {
            inputManager = PlayerManager.Instance.inputManager;
        }

        private void Update()
        {
            KeyUIColor();
        }

        public void KeyUIColor()
        {
            pressedW = inputManager.jumpInput;
            
            pressedA = inputManager.movementInput.x == -1 ? true : false;
            pressedD = inputManager.movementInput.x == 1 ? true : false;
        }

        #region Enable and Disable Keys
        public void UseKey(string keyName)
        {
            switch (keyName)
            {
                case "W":
                    canUseW = false;
                    break;
                case "A":
                    canUseA = false;
                    break;
                case "S":
                    canUseS = false;
                    break;
                case "D":
                    canUseD = false;
                    break;
            }
        }

        public void UnuseKey(EnchantType keyName)
        {
            switch (keyName)
            {
                case EnchantType.up:
                    canUseW = true;
                    break;
                case EnchantType.left:
                    canUseA = true;
                    break;
                case EnchantType.down:
                    canUseS = true;
                    break;
                case EnchantType.right:
                    canUseD = true;
                    break;
            }
        }
        #endregion
    }
}
