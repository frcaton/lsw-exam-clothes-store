using UnityEngine;
using UnityEngine.Tilemaps;

namespace ClothesStore {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float speed = 0.1f;

        [SerializeField]
        private Inventory inventory;
        public Inventory Inventory => inventory;

        private Animator animator;

        private Vector3Int currentCell;

        private bool isMoving = false;

        private Vector3 movingToCell;

        private void Awake() {
            animator = GetComponent<Animator>();
        }   

        private void Update() {

            if(isMoving) {            
                transform.Translate((movingToCell - transform.position) * speed);
                if(transform.position == movingToCell) {
                    isMoving = false;
                    currentCell = GameManager.Instance.World.WorldToCell(movingToCell);
                    CheckForMovementInput();
                }
            } else {
                CheckForMovementInput();
            }

            animator.SetBool("IsMoving", isMoving);

        }

        public void CheckForMovementInput() {
            float horizontalInput = Input.GetAxis("Horizontal");
            if(horizontalInput > 0) {                
                TryMoveToCell(currentCell + Vector3Int.right);
            } else if(horizontalInput < 0) {
                TryMoveToCell(currentCell + Vector3Int.left);
            } else {
                float verticalInput = Input.GetAxis("Vertical");
                if(verticalInput > 0) {
                    TryMoveToCell(currentCell + Vector3Int.up);
                } else if(verticalInput < 0) {
                    TryMoveToCell(currentCell + Vector3Int.down);
                }
            }
        }

        private void TryMoveToCell(Vector3Int position) {
            Tile tile = GameManager.Instance.World.GetTile<Tile>(position);
            if(tile.colliderType == Tile.ColliderType.None) {
            //if(tile.GetTileData()
                isMoving = true;
                movingToCell = GameManager.Instance.World.GetCellCenterWorld(position);
            } else {
                //TODO play sound
            }
        }

    }
    
}