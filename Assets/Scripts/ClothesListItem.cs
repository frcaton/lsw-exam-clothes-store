using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class ClothesListItem : MonoBehaviour {

        [SerializeField]
        private Image icon;
        
        [SerializeField]
        private Text nameTxt;
        
        [SerializeField]
        private Dropdown colorDrpDwn;
        
        [SerializeField]
        private Text priceTxt;

        private Toggle selectionTgl;
        public ToggleGroup Group {
            set => selectionTgl.group = value;
        }

        private Action<Clothes> onClothesSelectionChanged;
        public Action<Clothes> OnClothesSelectionChanged {
            set => onClothesSelectionChanged = value;
        }

        private bool isChangingClothesMutex = false;

        private List<Clothes> clothes;

        private void Awake() {
            selectionTgl = GetComponent<Toggle>();
            selectionTgl.isOn = false;
            selectionTgl.onValueChanged.AddListener(isOn => FireOnClothesSelectionChangedEvent());
            colorDrpDwn.onValueChanged.AddListener(value => OnColorSelectionChanged(value)); 
        }

        public void SetClothes(List<Clothes> clothes, Clothes clothesBeingTriedOfThisType) {
            this.clothes = clothes;

            int selectedColorIndex = 0;
            if(selectionTgl.isOn == (clothesBeingTriedOfThisType == null)) {                
                isChangingClothesMutex = true;
                selectionTgl.isOn = clothesBeingTriedOfThisType != null;

            }

            colorDrpDwn.ClearOptions();

            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>(clothes.Count);
            clothes.ForEach(c => options.Add(new Dropdown.OptionData(c.Color.ToString())));

            colorDrpDwn.AddOptions(options);
            colorDrpDwn.value = selectedColorIndex;

            nameTxt.text = clothes[0].Type.name;

            isChangingClothesMutex = false;
        }

        private void OnColorSelectionChanged(int index) {
            icon.sprite = clothes[index].Sprite;
            priceTxt.text = clothes[index].Price.ToString("$ #");
            if(selectionTgl.isOn) {
                FireOnClothesSelectionChangedEvent();                
            }
        }

        private void FireOnClothesSelectionChangedEvent() {
            if(!isChangingClothesMutex) {
                if(selectionTgl.isOn) {
                    onClothesSelectionChanged(clothes[colorDrpDwn.value]);
                } else {
                    onClothesSelectionChanged(null);
                }
            }
        }

    }

}
