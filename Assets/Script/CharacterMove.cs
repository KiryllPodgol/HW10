using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script
{
    public class CharacterMove : MonoBehaviour
    {
        private Vector3 targetPosition;
        private bool isMoving;
        [SerializeField] private float moveSpeed = 5.0f; // —корость движени€
        [SerializeField] private Tilemap tilemap; // Tilemap, по которому перемещаетс€ персонаж
        private PlayerAnimation playerAnimation;

        private void Awake()
        {
            targetPosition = transform.position;
            playerAnimation = GetComponent<PlayerAnimation>();
        }

        private void Update()
        {
            if (isMoving)
            {
                MoveToTarget();
                return;
            }

            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (input.magnitude > 0)
            {
                Vector3Int gridPosition = tilemap.WorldToCell(transform.position);
                Vector3Int moveDelta = new Vector3Int((int)input.x, (int)input.y, 0);
                Vector3Int newGridPosition = gridPosition + moveDelta;

                // ѕроверка, доступна ли клетка
                if (IsCellWalkable(newGridPosition))
                {
                    targetPosition = tilemap.CellToWorld(newGridPosition) + new Vector3(0.5f, 0.5f, 0); // ÷ентр клетки
                    isMoving = true;
                    playerAnimation.SetDirection(input);
                }
            }
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
                playerAnimation.SetDirection(Vector2.zero);
            }
        }

        private bool IsCellWalkable(Vector3Int gridPosition)
        {
            // ѕровер€ем, есть ли на клетке Tile
            TileBase tile = tilemap.GetTile(gridPosition);
            return tile != null; // «десь можно добавить дополнительные услови€, например, проверку на преп€тстви€
        }
    }
}
