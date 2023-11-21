using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PortalController : EnchantableObject
    {
        public GameObject upPortal;
        public GameObject downPortal;
        public GameObject leftPortal;
        public GameObject rightPortal;

        public GameObject idleSprite;

        public GameObject upSprite;
        public GameObject downSprite;
        public GameObject leftSprite;
        public GameObject rightSprite;

        public GameObject exit;

        public override void UpEvent()
        {
            base.UpEvent();
            currentEnchant = EnchantType.up;
        }
        public override void DownEvent()
        {
            base .DownEvent();
            currentEnchant = EnchantType.down;
        }
        public override void LeftEvent()
        {
            base.LeftEvent();
            currentEnchant = EnchantType.left;
        }
        public override void RightEvent()
        {
            base.RightEvent();
            currentEnchant = EnchantType.right;
        }
        public override void BaseEvent()
        {
            base.BaseEvent();
        }
        public override void SpaceEvent()
        {
            base.SpaceEvent();
            currentEnchant = EnchantType.space;
            transform.localScale = Vector3.one * 2;
        }
        public override void RetrieveEvent()
        {
            base.RetrieveEvent();
            currentEnchant = EnchantType.idle;
        }

        private void Update()
        {
            upSprite.SetActive(currentEnchant == EnchantType.up ? true:false);
            downSprite.SetActive(currentEnchant == EnchantType.down ? true:false);
            leftSprite.SetActive(currentEnchant == EnchantType.left ? true:false);
            rightSprite.SetActive(currentEnchant == EnchantType.right ? true:false);
            idleSprite.SetActive(currentEnchant == EnchantType.idle ? true:false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter Portal" + other.name);
            if (!other.GetComponent<InteractableObject>()) return;

            switch (currentEnchant)
            {
                case EnchantType.up:
                    if (upPortal)
                        other.gameObject.transform.position = upPortal.transform.position;
                    break;
                case EnchantType.down:
                    if (downPortal)
                        other.gameObject.transform.position = downPortal.transform.position;
                    break;
                case EnchantType.left:
                    if (leftPortal)
                        other.gameObject.transform.position = leftPortal.transform.position;
                    break;
                case EnchantType.right:
                    if (rightPortal)
                        other.gameObject.transform.position = rightPortal.transform.position;
                    break;
            }
        }
    }
}
