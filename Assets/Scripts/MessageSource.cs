using UnityEngine;

namespace ClothesStore {

    public class MessageSource : Interactable {

        [SerializeField]
        private Sprite Icn;

        [SerializeField]
        private string message;

        [SerializeField]
        private bool hasCancel = false;

        public override void Interact(PlayerController player) {
        }
        
    }

}