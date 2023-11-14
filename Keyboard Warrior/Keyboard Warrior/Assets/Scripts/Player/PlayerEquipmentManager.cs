using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardWarrior
{
    public class PlayerEquipmentManager : MonoBehaviour
    {
        [SerializeField] List<Equipment> equipments;
        bool equiped = false;
        public float invulnerableTime = 5f;

        private void Start()
        {
            equipments = GetComponentsInChildren<Equipment>().ToList();
            foreach (Equipment equip in equipments)
            {
                equip.gameObject.SetActive(false);
            }
        }
        public void Equip(GameObject relatedUI, string name)
        {
            Debug.Log(relatedUI + name);
            foreach (Equipment equipment in equipments)
            {
                if (equipment.equipmentName == name)
                {
                    equipment.gameObject.SetActive(true);
                    equipment.relatedUI = relatedUI;
                }
            }

        }

        public void UnEquip(GameObject equipmentObj)
        {
            Equipment equipment = equipmentObj.GetComponent<Equipment>();
            equipment.relatedUI.gameObject.SetActive(true);
            equipmentObj.SetActive(false);
            Invoke("EnablePlayerHealth", invulnerableTime);
        }

        void DisablePlayerHealth()
        {
            PlayerManager.Instance.playerHealth.enabled = false;
        }

        void EnablePlayerHealth()
        {
            PlayerManager.Instance.playerHealth.enabled = true;
        }
    }
}
