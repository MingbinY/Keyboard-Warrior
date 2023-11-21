using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerSkillManager : MonoBehaviour
    {
        public GameObject wUI;
        public GameObject aUI;
        public GameObject sUI;
        public GameObject dUI;
        public GameObject spaceUI;

        public void RetrieveObstacle(KeyboardObstacle obstacle)
        {
            obstacle.relatedKeyUI.SetActive(true);
            obstacle.gameObject.SetActive(false);
            PlayerManager.Instance.playerKeyboardManager.UnuseKey(obstacle.obstacleName);
        }

        public void RetrieveEnchantment(string enchantName)
        {
            switch (enchantName)
            {
                case "W":
                    wUI.SetActive(true);
                    break;
                case "A":
                    aUI.SetActive(true);
                    break;
                case "S":
                    sUI.SetActive(true);
                    break;
                case "D":
                    dUI.SetActive(true);
                    break;
                case "Space":
                    spaceUI.SetActive(true);
                    break;
            }
            InteractableObject[] enchantableObjects = FindObjectsOfType<InteractableObject>();
            foreach (InteractableObject obj in enchantableObjects)
            {
                obj.RetrieveEvent();
            }
            PlayerManager.Instance.playerKeyboardManager.UnuseKey(enchantName);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            EnchantableObject enchantableObject = other.GetComponent<EnchantableObject>();
            if (enchantableObject && enchantableObject.currentEnchant == EnchantType.up && enchantableObject.enchanted)
            {
                RetrieveEnchantment("W");
            }
        }
    }
}
