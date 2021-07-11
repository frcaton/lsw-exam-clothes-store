using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ClothesStore {
    
    public class CategoryToggle : MonoBehaviour {

        [SerializeField]
        private BodyPart bodyPart;
        public BodyPart BodyPart => bodyPart;

        private Toggle tgl;
        public bool IsSelected {
            get => tgl.isOn;
            set {                
                tgl.isOn = value;
                OnToggleValueChanged(value);
            } 
        } 

        private UnityAction<BodyPart> onSelected;
        public UnityAction<BodyPart> OnSelected {
            set => onSelected = value;
        }

        private void Awake() {
            tgl = GetComponent<Toggle>();
            tgl.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn) {
            if(isOn) {
                onSelected?.Invoke(bodyPart);
            }
        }

    }

}
