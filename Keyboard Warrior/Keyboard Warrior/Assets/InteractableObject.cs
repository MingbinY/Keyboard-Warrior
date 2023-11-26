using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KeyboardWarrior
{
    public class InteractableObject : MonoBehaviour
    {
        public GameObject idleObject;
        public GameObject upObject;
        public GameObject downObject;
        public GameObject leftObject;
        public GameObject rightObject;

        public EnchantType defaultType = EnchantType.idle;
        public EnchantType currenttype = EnchantType.idle;

        EnchantableObject eo;
        private void Start()
        {
            currenttype = defaultType;
            eo = GetComponent<EnchantableObject>();
        }

        public void OnEnchant(EnchantType enchantType)
        {
            Debug.Log("New Type: " + enchantType);
            currenttype = enchantType;
            StartCoroutine(AutoReterieve());
        }

        IEnumerator AutoReterieve()
        {
            yield return new WaitForSeconds(PlayerManager.Instance.playerSkillManager.enchantLastTime);
            PlayerManager.Instance.playerSkillManager.RetrieveEnchantment(currenttype);
            eo.BaseEvent();
            currenttype = defaultType;
        }

        private void Update()
        {
            switch (currenttype)
            {
                case EnchantType.idle:
                    break;
                case EnchantType.up:
                    eo.UpEvent();
                    break;
                case EnchantType.down:
                    eo.DownEvent();
                    break;
                case EnchantType.left:
                    eo.LeftEvent();
                    break;
                case EnchantType.right:
                    eo.RightEvent();
                    break;
            }
        }
    }
}
