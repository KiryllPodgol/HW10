using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        private PlayerAnimation playerAnimation;
        private Rigidbody2D rb;

        [SerializeField] private float moveSpeed = 1.0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            playerAnimation = GetComponent<PlayerAnimation>();
        }

        private void FixedUpdate()
        {
            Vector2 currentPos = rb.position;
            float moveH = Input.GetAxis("Horizontal") * moveSpeed;
            float moveV = Input.GetAxis("Vertical") * moveSpeed;
            Vector2 inputVector = new Vector2(moveH, moveV);

            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * moveSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

            rb.MovePosition(newPos);
            playerAnimation.SetDirection(inputVector);
        }
    }
}
