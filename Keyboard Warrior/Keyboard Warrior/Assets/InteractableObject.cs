using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        public EnchantableObject eo;
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
            eo.currentEnchant = currenttype;
            Debug.Log(name + ' ' + currenttype + " IDLE OBJECT " + idleObject.activeSelf);
            if (gameObject == PlayerManager.Instance.gameObject) return;
            idleObject.active = currenttype == EnchantType.idle ? true:false;
            upObject.active = currenttype == EnchantType.up ? true:false;
            downObject.active = currenttype == EnchantType.down ? true:false;
            leftObject.active = currenttype == EnchantType.left ? true:false;
            rightObject.active = currenttype == EnchantType.right ? true:false;
        }
    }
}
