using UnityEngine;
using UnityEngine.InputSystem;

namespace KeyboardWarrior
{
    public class InputManager : MonoBehaviour
    {
        PlayerMovement playerMovement;
        private PlayerInput playerInput;
        private PlayerInputActions inputActions;
        private PlayerKeyboardManager keyboardManager;
        private PlayerLadderMovement ladderMovement;

        public Vector2 movementInput;
        public Vector2 climbInput;
        public bool jumpInput;
        public bool retrieveInput;

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            inputActions = new PlayerInputActions();
            inputActions.Player.Enable();
            inputActions.Player.Jump.performed += JumpInput;
            inputActions.Player.Retrieve.started += i => retrieveInput = true;
            inputActions.Player.Retrieve.canceled += i => retrieveInput = false;
            inputActions.Player.Restart.performed += RespawnInput;
        }

        private void Start()
        {
            playerMovement = PlayerManager.Instance.playerMovement;
            keyboardManager = PlayerManager.Instance.playerKeyboardManager;
            ladderMovement = PlayerManager.Instance.ladderMovement;
        }

        private void Update()
        {
            MoveInput(inputActions.Player.Move.ReadValue<Vector2>());
            ClimbInput(inputActions.Player.Climb.ReadValue<Vector2>());
            if (retrieveInput)
            {

            }
        }

        public void JumpInput(InputAction.CallbackContext context)
        {
            if (!keyboardManager.canUseSpace) return;
            if (context.performed)
                keyboardManager.pressedSpace = true;
            playerMovement.HandleJump();
        }

        public void MoveInput(Vector2 value)
        {
            if (!keyboardManager.canUseA && value.x == -1) return;
            if (!keyboardManager.canUseD && value.x == 1) return;

            keyboardManager.pressedA = value.x == -1 ? true : false;
            keyboardManager.pressedD = value.x == 1 ? true : false;

            movementInput = value;
            playerMovement.HandleMove(value);
        }

        public void ClimbInput(Vector2 value)
        {
            if (!keyboardManager.canUseW) return;
            climbInput = value;
            ladderMovement.StartClimbing(value.y);
        }

        public void RespawnInput(InputAction.CallbackContext context)
        {
            GameManager.Instance.Respawn();
        }
    }
}
