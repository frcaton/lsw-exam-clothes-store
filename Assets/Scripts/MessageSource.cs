using UnityEngine;
using UnityEngine.Events;

namespace ClothesStore {

    public class MessageSource : Interactable {

        [SerializeField]
        private Sprite Icn;

        [SerializeField, TextArea]
        private string message;
        
        [SerializeField]
        private string option1Txt;
        
        [SerializeField]
        private string option2Txt;

        [SerializeField]
        private UnityEvent<bool> onOptionChosen;

        public override void Interact(PlayerController player) {
            if(option2Txt.Length > 0) {
                MessagePanel.Instance.Show(Icn, message, option1Txt, option2Txt, OnOption1Chosen, OnOption2Chosen);
            } else {
                MessagePanel.Instance.Show(Icn, message, option1Txt, OnOption1Chosen);
            }            
        }

        private void OnOption1Chosen() {
            onOptionChosen?.Invoke(true);
        }

        private void OnOption2Chosen() {
            onOptionChosen?.Invoke(false);
        }
        
    }

}