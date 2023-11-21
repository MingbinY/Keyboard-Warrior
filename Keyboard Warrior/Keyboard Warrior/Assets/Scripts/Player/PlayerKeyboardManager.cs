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
            pressedW = inputManager.retrieveInput;
            if (pressedW )
            {
                retrieveTimer += Time.deltaTime;
            }
            else
            {
                retrieveTimer = 0;
                activatedRetrieve = false;
            }

            if (retrieveTimer >= retrieveTime)
            {
                activatedRetrieve = true;
                RetrieveKeys();
            }
        }

        public void KeyUIColor()
        {
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
                case "Space":
                    canUseSpace = false;
                    break;
            }
        }

        public void UnuseKey(string keyName)
        {
            switch (keyName)
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
                case "Space":
                    canUseSpace = true;
                    break;
            }
        }
        #endregion
        private void RetrieveKeys()
        {
            string[] keys = { "W", "A", "S", "D", "Space" };
            KeyboardObstacle[] obstacles = FindObjectsOfType<KeyboardObstacle>();

            foreach (string key in keys)
            {
                PlayerManager.Instance.playerSkillManager.RetrieveEnchantment(key);
            }

            foreach (KeyboardObstacle obstacle in obstacles)
            {
                if (obstacle.gameObject.activeSelf)
                {
                    PlayerManager.Instance.playerSkillManager.RetrieveObstacle(obstacle);
                }
            }

            PlayerManager.Instance.playerSkillManager.RetrieveAllEnchantment();
        }
    }
}
