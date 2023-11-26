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

        PlayerKeyboardManager keyboardManager;

        private void Start()
        {
            keyboardManager = PlayerManager.Instance.playerKeyboardManager;
        }

        public float enchantLastTime = 5f;

        public void RetrieveEnchantment(EnchantType enchantType)
        {        
            PlayerManager.Instance.playerKeyboardManager.UnuseKey(enchantType);
        }

        private void Update()
        {
            wUI.SetActive(keyboardManager.canUseW);
            aUI.SetActive(keyboardManager.canUseA);
            sUI.SetActive(keyboardManager.canUseS);
            dUI.SetActive(keyboardManager.canUseD);
        }
    }
}
