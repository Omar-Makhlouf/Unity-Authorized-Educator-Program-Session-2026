using UnityEngine;
using UnityEngine.InputSystem;

namespace TerrainClassroom
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class ClassroomFirstPersonController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActions;
        [SerializeField] private Transform view;
        [SerializeField, Min(0.1f)] private float walkSpeed = 5f;
        [SerializeField, Min(0.1f)] private float sprintSpeed = 8f;
        [SerializeField, Min(0f)] private float jumpHeight = 1.2f;
        [SerializeField, Min(0.01f)] private float mouseSensitivity = 0.12f;
        [SerializeField] private float gravity = -22f;

        private CharacterController controller;
        private InputActionAsset runtimeActions;
        private InputActionMap playerMap;
        private InputAction moveAction;
        private InputAction lookAction;
        private InputAction jumpAction;
        private InputAction sprintAction;
        private Vector3 spawnPosition;
        private Quaternion spawnRotation;
        private float verticalSpeed;
        private float pitch;
        private bool inputCaptured;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            spawnPosition = transform.position;
            spawnRotation = transform.rotation;
            if (inputActions == null || view == null)
            {
                Debug.LogError("Assign the classroom input actions and player camera.", this);
                enabled = false;
                return;
            }

            // Own a copy so enabling this player never changes the shared project asset.
            runtimeActions = Instantiate(inputActions);
            runtimeActions.bindingMask = InputBinding.MaskByGroup("Keyboard&Mouse");
            playerMap = runtimeActions.FindActionMap("Player", true);
            moveAction = playerMap.FindAction("Move", true);
            lookAction = playerMap.FindAction("Look", true);
            jumpAction = playerMap.FindAction("Jump", true);
            sprintAction = playerMap.FindAction("Sprint", true);
        }

        private void OnEnable()
        {
            if (playerMap == null) return;
            playerMap.Enable();
            CaptureInput(true);
        }

        private void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
                CaptureInput(false);
            else if (!inputCaptured && Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
                CaptureInput(true);

            if (inputCaptured && keyboard != null && keyboard.rKey.wasPressedThisFrame)
                Respawn();

            var movement = Vector2.zero;
            if (inputCaptured)
            {
                movement = Vector2.ClampMagnitude(moveAction.ReadValue<Vector2>(), 1f);
                // Mouse delta is already a per-frame displacement: do not multiply by deltaTime.
                var look = lookAction.ReadValue<Vector2>() * mouseSensitivity;
                transform.Rotate(0f, look.x, 0f);
                pitch = Mathf.Clamp(pitch - look.y, -85f, 85f);
                view.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            }

            if (controller.isGrounded && verticalSpeed < 0f) verticalSpeed = -2f;
            if (inputCaptured && controller.isGrounded && jumpAction.WasPressedThisFrame())
                verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
            verticalSpeed += gravity * Time.deltaTime;
            float speed = inputCaptured && sprintAction.IsPressed() ? sprintSpeed : walkSpeed;
            var velocity = (transform.right * movement.x + transform.forward * movement.y) * speed;
            velocity.y = verticalSpeed;
            var flags = controller.Move(velocity * Time.deltaTime);
            if ((flags & CollisionFlags.Above) != 0 && verticalSpeed > 0f) verticalSpeed = 0f;
            if (transform.position.y < -30f) Respawn();
        }

        private void Respawn()
        {
            controller.enabled = false;
            transform.SetPositionAndRotation(spawnPosition, spawnRotation);
            controller.enabled = true;
            verticalSpeed = 0f;
            pitch = 0f;
            view.localRotation = Quaternion.identity;
        }

        private void CaptureInput(bool capture)
        {
            inputCaptured = capture;
            Cursor.lockState = capture ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !capture;
        }

        private void OnApplicationFocus(bool focused)
        {
            if (!focused) CaptureInput(false);
        }

        private void OnDisable()
        {
            playerMap?.Disable();
            CaptureInput(false);
        }

        private void OnDestroy()
        {
            if (runtimeActions != null) Destroy(runtimeActions);
        }
    }
}
