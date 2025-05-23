
using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class Player : MonoBehaviour
    {
    
        [SerializeField] float movementspeed = 5f;
        [SerializeField] InputManager inputManager;
        [SerializeField] CharacterController characterController;
        [SerializeField] float gravityScale = -9.81f;
        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float groundCheckRadius;
        [SerializeField] float jumpHeight;
        private Rigidbody _rb;
        Transform _mainCamera;
        Vector3 _direction;
        Vector3 _verticalDirection;
        Vector3 _movement;
        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            if (Camera.main != null) _mainCamera = Camera.main.transform;
            Cursor.lockState = CursorLockMode.Locked;
            inputManager.OnMove += Move;
            inputManager.OnJump += Jump;
           // inputManager.OnDash += Dash;
        }

        private void OnDisable()
        {
            inputManager.OnMove -= Move;
            inputManager.OnJump -= Jump;
        }

        private void Update()
        {
                _direction = _mainCamera.forward*_movement.z + _mainCamera.right*_movement.x;
                _direction.y = 0;
                characterController.Move(_direction* (movementspeed *Time.deltaTime));
                ApplyGravity();
        }


        private void Jump()
        {
            if (OnGround())
            {
                var currentHeight = transform.position.y;
                _verticalDirection.y = Mathf.Sqrt(-2 * gravityScale * jumpHeight);
                characterController.Move(_verticalDirection * Time.deltaTime);
                if (transform.position.y <= currentHeight+0.3)
                {
                    _verticalDirection.y = Mathf.Sqrt(-2 * gravityScale * jumpHeight);
                    characterController.Move(_verticalDirection * Time.deltaTime);
                }
            }
        }
        private void Move(Vector2 direction)
        {
            _movement = new Vector3(direction.x, 0, direction.y);
        }
    
        private void ApplyGravity()
        {
            characterController.Move(_verticalDirection * Time.deltaTime);
            if (OnGround())
            {
                _verticalDirection.y = 0;
                return;
            }
            _verticalDirection.y += gravityScale * Time.deltaTime;
        }
        private bool OnGround()
        {
          return  Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        }
        private void OnDrawGizmos()
        {
           Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        }

   
    }
}
