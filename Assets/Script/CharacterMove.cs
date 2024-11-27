using UnityEngine;
using UnityEngine.InputSystem;
namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
        [SerializeField] private Transform movePoint;
        [SerializeField] private LayerMask obstacleMask;

        void Start()
        {
            movePoint.parent = null;
        }

        void Update()
        {
            float movementAmout = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);

            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                }
            }
        }
        private void Move(Vector3 direction)
        {
            Vector3 newPosition = movePoint.position + direction;
            if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask))
            {
                movePoint.position = newPosition;
            }
        }
    }
}