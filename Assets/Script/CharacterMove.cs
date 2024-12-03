using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        private Rigidbody2D rb;
        private InputAsset input;
        private Vector2 _direction;
        private PlayerAnimation playerAnimation;

        [SerializeField] private Grid terrainCells; 
        [SerializeField] private float speed = 5.0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            input = new InputAsset();
            playerAnimation = GetComponent<PlayerAnimation>();
        }

        private void Start()
        {
            input.Gameplay.Move.performed += Move_performed; 
            input.Gameplay.Move.canceled += Move_canceled; 
            input.Enable();
        }

        private void OnDestroy()
        {
            input.Gameplay.Move.performed -= Move_performed; 
            input.Gameplay.Move.canceled -= Move_canceled; 
            input.Disable();
        }

        private void Move_performed(InputAction.CallbackContext obj)
        {
            _direction = obj.ReadValue<Vector2>();
            if (_direction.magnitude > 1) _direction.Normalize();
            playerAnimation.SetDirection(_direction); 
        }

        private void Move_canceled(InputAction.CallbackContext obj)
        {
            _direction = Vector2.zero; 
            playerAnimation.SetDirection(Vector2.zero); 
        }

        private void FixedUpdate()
        {
            MoveCharacter(); 
        }

        private void MoveCharacter()
        {
            Vector3 cellSize = terrainCells.cellSize;
            
            // Учитываем соотношение сторон клетки при движении
            Vector2 adjustedDirection = new Vector2(_direction.x, _direction.y * (cellSize.y / cellSize.x));
            
            // Рассчитываем новое движение
            Vector2 movement = adjustedDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
            Vector3Int cellPosition = terrainCells.WorldToCell(rb.position);
       
        }
    }
}