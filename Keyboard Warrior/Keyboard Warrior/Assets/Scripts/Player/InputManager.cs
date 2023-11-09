using UnityEngine;
using UnityEngine.InputSystem;

namespace KeyboardWarrior
{
    public class InputManager : MonoBehaviour
    {
        PlayerMovement playerMovement;
        private PlayerInput playerInput;
        private PlayerInputActions inputActions;

        public Vector2 movementInput;

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerInput = GetComponent<PlayerInput>();

            inputActions = new PlayerInputActions();
            inputActions.Player.Enable();
            inputActions.Player.Jump.performed += JumpInput;
        }

        private void Update()
        {
            MoveInput(inputActions.Player.Move.ReadValue<Vector2>());
        }

        public void JumpInput(InputAction.CallbackContext context)
        {
            if (context.performed)
                playerMovement.HandleJump();
        }

        public void MoveInput(Vector2 value)
        {
            movementInput = value;
            playerMovement.HandleMove(value);
        }


    }
}
