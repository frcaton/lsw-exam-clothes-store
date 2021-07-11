using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class ListItem : MonoBehaviour {

        [SerializeField]
        protected Image icon;
        
        [SerializeField]
        protected Text nameTxt;
        
        [SerializeField]
        protected Text amountTxt;
       
        [SerializeField]
        protected Toggle selectionTgl;
        public bool IsSelected {
            set {
                selectionTgl.isOn = value;
                OnSelectionTglValueChanged(value);
            }
        }

        protected virtual void Awake() {
            selectionTgl.isOn = false;
            selectionTgl.onValueChanged.AddListener(OnSelectionTglValueChanged);
        }

        protected virtual void OnSelectionTglValueChanged(bool isOn) {

        }

    }

}
