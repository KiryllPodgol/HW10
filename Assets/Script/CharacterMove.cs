using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float moveH, moveV;
        [SerializeField] private float moveSpeed = 1.0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
            rb.linearVelocity = new Vector2(moveH, moveV);

            Vector2 direction = new Vector2(moveH, moveV);

            PlayerAnimation playerAnimation = FindObjectOfType<PlayerAnimation>();
            if (playerAnimation != null)
            {
                playerAnimation.SetDirection(direction);
            }
            else
            {
                Debug.LogError("PlayerAnimation component not found in the scene.");
            }
        }
    }
}