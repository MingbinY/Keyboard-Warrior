using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class Equipment : MonoBehaviour
    {
        public GameObject relatedUI;
        public string equipmentName;

        private void OnMouseOver()
        {
            Debug.Log("UnEquip");
            
            if (Input.GetMouseButtonDown(0))
            {
                PlayerManager.Instance.playerKeyboardManager.UnuseKey(name);
                PlayerManager.Instance.playerEquipmentManager.UnEquip(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<DeathCollider>() != null)
            {
                PlayerManager.Instance.playerKeyboardManager.UnuseKey(name);
                PlayerManager.Instance.playerEquipmentManager.UnEquip(gameObject);
            }
        }
    }
}
