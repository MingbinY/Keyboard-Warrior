using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Start()
        {
            inputManager = PlayerManager.Instance.inputManager;
        }

        public void UseKey(string name)
        {
            switch (name)
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

        public void UnuseKey(string name)
        {
            switch (name)
            {
                case "W":
                    canUseW = true;
                    break;
                case "A":
                    canUseA = true;
                    break;
                case "S":
                    canUseS = true;
                    break;
                case "D":
                    canUseD = true;
                    break;
            }
        }
    }
}
