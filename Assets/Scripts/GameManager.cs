
using Action = System.Action;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

using Mimic;

namespace ClothesStore {

    public class GameManager : Singleton<GameManager> {

        [SerializeField]
        private int money;
        public int Money {
            get => money;
            set => money = Mathf.Max(0, value);
        }

        [SerializeField]
        private PlayerController player;

        [SerializeField]
        private Tilemap world;
        public Tilemap World => world;

        [SerializeField]
        private Transform interactablesParent;

        private List<Interactable> interactables;

        private void Awake() {
            interactables = new List<Interactable>(interactablesParent.GetComponentsInChildren<Interactable>());
        }

        private void Update() {
            Vector3 cameraPosition = Camera.main.transform.position;
            cameraPosition.x = player.transform.position.x;
            cameraPosition.y = player.transform.position.y;
            Camera.main.transform.position = cameraPosition;

            if(!player.IsMoving && Input.GetButtonDown("Action"))  {
                Interactable interactable = interactables.Find(interactable => interactable.CanInteract(player));
                interactable?.Interact(player);
            }

        }

        public void TeleportPlayer(Vector3Int targetCell, Action onFinish) {
            UIManager.Instance.DoTransition(() => {
                player.CurrentCell = targetCell;
                onFinish();
            });
        }

    }
    
}