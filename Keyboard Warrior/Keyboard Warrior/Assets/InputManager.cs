using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class InputManager : MonoBehaviour
    {
        PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if ()
            if (Input.GetKey("space"))
            {
                playerMovement.HandleJump();
            }
        }


    }
}
