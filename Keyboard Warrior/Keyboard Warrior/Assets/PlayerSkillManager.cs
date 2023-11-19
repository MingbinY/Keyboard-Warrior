using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlayerSkillManager : MonoBehaviour
    {
        public void RetrieveObstacle(KeyboardObstacle obstacle)
        {
            obstacle.relatedKeyUI.SetActive(true);
            obstacle.gameObject.SetActive(false);
            PlayerManager.Instance.playerKeyboardManager.UnuseKey(obstacle.obstacleName);
        }

        public void RetrieveEnchantment(string enchantName)
        {

        }
    }
}
