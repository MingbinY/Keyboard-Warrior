using UnityEngine;
using UnityEngine.InputSystem;

namespace KeyboardWarrior
{
    public class InputManager : MonoBehaviour
    {
        PlayerMovement playerMovement;
        private PlayerInput playerInput;
        private PlayerInputActions inputActions;
        public bool canUseW = true;
        public bool canUseA = true;
        public bool canUseS = true;
        public bool canUseD = true;
        public bool canUseSpace = true;

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
            if (!canUseSpace)
                return;
            if (context.performed)
                playerMovement.HandleJump();
        }

        public void MoveInput(Vector2 value)
        {
            if (!canUseA && value.x == -1) return;
            if (!canUseD && value.x == 1) return;
            movementInput = value;
            playerMovement.HandleMove(value);
        }


    }
}
