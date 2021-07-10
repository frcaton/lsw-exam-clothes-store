using UnityEngine;
using UnityEngine.Tilemaps;

namespace ClothesStore {

    public class VisibleDoor : Door {

        [SerializeField]
        private Tilemap tilemap;

        [SerializeField]
        private Tile doorOpenTile;

        [SerializeField]
        private Tile doorShutTile;

        [SerializeField]
        private float teleportDelay = 0.1f;

        public override void Interact(PlayerController player) {
            Open();
            Invoke(nameof(StartTeleport), teleportDelay);
        }

        protected override void OnTeleportFinished() {
            Shut();
        }

        public void Open() {
            ChangeTile(doorOpenTile);
        }

        public void Shut() {
            ChangeTile(doorShutTile);
        }

        private void ChangeTile(Tile tile) {
            tilemap.SetTile(tilemap.WorldToCell(transform.position), tile);
        }
        
    }

}