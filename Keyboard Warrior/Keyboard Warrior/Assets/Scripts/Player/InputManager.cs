using UnityEngine;
using UnityEngine.InputSystem;

namespace KeyboardWarrior
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputActions inputActions;
        private PlayerKeyboardManager keyboardManager;
        private PlayerLadderMovement ladderMovement;

        public Vector2 movementInput;
        public Vector2 climbInput;
        public bool jumpInput;

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void Awake()
        {
            inputActions = new PlayerInputActions();
            inputActions.Player.Enable();
            inputActions.Player.Jump.performed += i => jumpInput = true;
            inputActions.Player.Jump.canceled += i => jumpInput = false;
            inputActions.Player.Restart.performed += RespawnInput;
        }

        private void Start()
        {
            keyboardManager = PlayerManager.Instance.playerKeyboardManager;
            ladderMovement = PlayerManager.Instance.ladderMovement;
        }

        private void Update()
        {
            MoveInput(inputActions.Player.Move.ReadValue<Vector2>());
            ClimbInput(inputActions.Player.Climb.ReadValue<Vector2>());
        }

        public void MoveInput(Vector2 value)
        {
            movementInput = value;
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
