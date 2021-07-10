using UnityEngine;
using UnityEngine.Tilemaps;

namespace ClothesStore {

    public class Door : Interactable {

        [SerializeField]
        private Door otherSide;

        [SerializeField]
        private Vector2Int teleportOffset;

        public override void Interact(PlayerController player) {
            StartTeleport();
        }

        protected void StartTeleport() {
            Vector3Int targetCell = GameManager.Instance.World.WorldToCell(otherSide.transform.position) + (Vector3Int) teleportOffset;
            GameManager.Instance.TeleportPlayer(targetCell, OnTeleportFinished);
        }

        protected virtual void OnTeleportFinished() {

        }
        
    }

}