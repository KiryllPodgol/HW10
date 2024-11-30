using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        private Rigidbody2D rb;
        private InputAsset input;
        private Vector3 _direction;
        private PlayerAnimation playerAnimation;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            input = new InputAsset();
            playerAnimation = GetComponent<PlayerAnimation>();
        }

        private void Start()
        {
            input.Gameplay.Move.performed += Move_performed; // Используем performed
            input.Enable();
        }

        private void OnDestroy()
        {
            input.Gameplay.Move.performed -= Move_performed;
            input.Disable();
        }

        private void Move_performed(InputAction.CallbackContext obj)
        {
            Vector2 readVector = obj.ReadValue<Vector2>();
            Vector3 toConvert = new Vector3(readVector.x, 0, readVector.y);
            _direction = IsoVectorConvert(toConvert);

            playerAnimation.SetDirection(new Vector2(_direction.x, _direction.z));
        }

        private void FixedUpdate()
        {
            MoveCharacter(); 
        }

        private void MoveCharacter()
        {
            rb.MovePosition(rb.position + new Vector2(_direction.x, _direction.z) * Time.fixedDeltaTime);
        }

        private Vector3 IsoVectorConvert(Vector3 vector)
        {
            Quaternion rotation = Quaternion.Euler(0, 45.0f, 0);
            Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);
            Vector3 result = isoMatrix.MultiplyPoint3x4(vector);
            return result;
        }
    }
}
