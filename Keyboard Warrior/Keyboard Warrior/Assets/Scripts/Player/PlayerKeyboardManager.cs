using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerKeyboardManager : MonoBehaviour
    {
        InputManager inputManager;

        private void Start()
        {
            inputManager = PlayerManager.Instance.inputManager;
        }

        public void UseKey(string name)
        {
            switch (name)
            {
                case "W":
                    inputManager.canUseW = false;
                    break;
                case "A":
                    inputManager.canUseA = false;
                    break;
                case "S":
                    inputManager.canUseS = false;
                    break;
                case "D":
                    inputManager.canUseD = false;
                    break;
            }
        }

        public void UnuseKey(string name)
        {
            switch (name)
            {
                case "W":
                    inputManager.canUseW = true;
                    break;
                case "A":
                    inputManager.canUseA = true;
                    break;
                case "S":
                    inputManager.canUseS = true;
                    break;
                case "D":
                    inputManager.canUseD = true;
                    break;
            }
        }
    }
}
