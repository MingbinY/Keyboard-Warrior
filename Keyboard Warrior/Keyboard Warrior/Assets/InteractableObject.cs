using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class InteractableObject : MonoBehaviour
    {
        public GameObject idleObject;
        public GameObject upObject;
        public GameObject downObject;
        public GameObject leftObject;
        public GameObject rightObject;

        public void OnInteract(string name)
        {
            idleObject.SetActive(false);
            switch (name)
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
            }
        }
    }
}
