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
        public GameObject spaceObject;

        public UnityEvent upEvent;
        public UnityEvent downEvent;
        public UnityEvent leftEvent;
        public UnityEvent rightEvent;
        public UnityEvent spaceEvent;
        public UnityEvent baseEvent;

        public float enchantTime;

        public void OnInteract(string enchantDirection)
        {
            idleObject.SetActive(false);
            Debug.Log(enchantDirection + "enchantDirection");
            switch (enchantDirection)
            {
                case "W":
                    upObject.SetActive(true);
                    break;
                case "S":
                    downObject.SetActive(true);
                    break;
                case "A":
                    leftObject.SetActive(true);
                    break;
                case "D":
                    rightObject.SetActive(true);
                    break;
                case "Space":
                    spaceObject.SetActive(true);
                    break;
            }
            StartCoroutine(Enchantment(enchantDirection));
        }

        IEnumerator Enchantment(string direction)
        {
            switch (direction)
            {
                case "W":
                    upEvent.Invoke();
                    break;
                case "S":
                    downEvent.Invoke();
                    break;
                case "A":
                    leftEvent.Invoke();
                    break;
                case "D":
                    rightEvent.Invoke();
                    break;
                case "Space":
                    spaceEvent.Invoke();
                    break;
            }

            yield return new WaitForSeconds(enchantTime);
            baseEvent.Invoke();
            PlayerManager.Instance.playerSkillManager.RetrieveEnchantment(direction);
        }
    }
}
