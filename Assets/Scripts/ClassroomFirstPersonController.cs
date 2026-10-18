using UnityEngine;
using UnityEngine.InputSystem;

namespace TerrainClassroom
{
    /// <summary>
    /// Lets students explore their terrain with a capsule, mouse look, and keyboard controls.
    /// Uses CharacterController movement and applies gravity without a Rigidbody.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public sealed class ClassroomFirstPersonController : MonoBehaviour
    {
        // Assign the shared action asset and child camera in the player prefab.
        [SerializeField] private InputActionAsset inputActions;
        [SerializeField] private Transform view;
        // Speeds are metres per second; jump height is in metres and gravity in metres per second squared.
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
            // Remember this scene's placement so R returns to the teacher's chosen starting point.
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
            // Awake can disable this component if its required references are missing.
            if (playerMap == null) return;
            playerMap.Enable();
            CaptureInput(true);
        }

        private void Update()
        {
            // Escape frees the mouse for the Editor; clicking captures it for exploration again.
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
                // Clamp diagonal input so moving forward and sideways is not faster than walking straight.
                movement = Vector2.ClampMagnitude(moveAction.ReadValue<Vector2>(), 1f);
                // Mouse delta is already a per-frame displacement: do not multiply by deltaTime.
                var look = lookAction.ReadValue<Vector2>() * mouseSensitivity;
                // Turn the capsule horizontally; tilt only the camera so walking stays level.
                transform.Rotate(0f, look.x, 0f);
                pitch = Mathf.Clamp(pitch - look.y, -85f, 85f);
                view.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            }

            // A small downward speed maintains ground contact without accumulating fall speed.
            if (controller.isGrounded && verticalSpeed < 0f) verticalSpeed = -2f;
            if (inputCaptured && controller.isGrounded && jumpAction.WasPressedThisFrame())
                // Convert the requested jump height into the initial upward speed under this gravity.
                verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
            // CharacterController.Move does not apply gravity; keep falling even with the cursor released.
            verticalSpeed += gravity * Time.deltaTime;
            float speed = inputCaptured && sprintAction.IsPressed() ? sprintSpeed : walkSpeed;
            // Convert local input into movement relative to the direction the capsule faces.
            var velocity = (transform.right * movement.x + transform.forward * movement.y) * speed;
            velocity.y = verticalSpeed;
            // Move expects a distance for this frame, rather than a velocity.
            var flags = controller.Move(velocity * Time.deltaTime);
            // Cancel upward motion on a ceiling hit and recover if the player falls off the terrain.
            if ((flags & CollisionFlags.Above) != 0 && verticalSpeed > 0f) verticalSpeed = 0f;
            if (transform.position.y < -30f) Respawn();
        }

        private void Respawn()
        {
            // Temporarily disable the collider to teleport, then clear falling speed and camera tilt.
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
            // Returning to another window should not leave the mouse locked to the game.
            if (!focused) CaptureInput(false);
        }

        private void OnDisable()
        {
            playerMap?.Disable();
            CaptureInput(false);
        }

        private void OnDestroy()
        {
            // Clean up the runtime copy; the shared project action asset remains untouched.
            if (runtimeActions != null) Destroy(runtimeActions);
        }
    }
}
