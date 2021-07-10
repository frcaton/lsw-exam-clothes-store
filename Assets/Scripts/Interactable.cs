using UnityEngine;

namespace ClothesStore {

    public abstract class Interactable : MonoBehaviour {

        private Collider2D collider;

        protected virtual void Awake() {
            collider = GetComponent<Collider2D>();
        }

        public bool CanInteract(PlayerController player) {
            return collider.OverlapPoint(GameManager.Instance.World.GetCellCenterWorld(player.CurrentCell + Vector3Int.up))
                || collider.OverlapPoint(GameManager.Instance.World.GetCellCenterWorld(player.CurrentCell + Vector3Int.down))
                || collider.OverlapPoint(GameManager.Instance.World.GetCellCenterWorld(player.CurrentCell + Vector3Int.left))
                || collider.OverlapPoint(GameManager.Instance.World.GetCellCenterWorld(player.CurrentCell + Vector3Int.right));            
        }

        public abstract void Interact(PlayerController player);
        
    }

}