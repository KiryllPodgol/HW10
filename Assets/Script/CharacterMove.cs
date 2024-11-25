using UnityEngine;

namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private Rigidbody2D rb;
        private float _moveH, _moveV;
        [SerializeField] private float _speed = 2.0f;
        
        
        void Start()
        {
         rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
         _moveH = Input.GetAxisRaw("Horizontal")*_speed;
         _moveV = Input.GetAxisRaw("Vertical")*_speed;
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(_moveH, _moveV);
        }
    }
}
