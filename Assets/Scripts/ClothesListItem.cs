using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class ClothesListItem : ListItem {
        
        [SerializeField]
        private Dropdown colorDrpDwn;

        public ToggleGroup Group {
            set => selectionTgl.group = value;
        }

        private Action<Clothes> onClothesSelectionChanged;
        public Action<Clothes> OnClothesSelectionChanged {
            set => onClothesSelectionChanged = value;
        }

        private bool isChangingClothesMutex = false;

        private List<Clothes> clothes;

        private bool buy;

        protected override void Awake() {
            base.Awake();
            colorDrpDwn.onValueChanged.AddListener(value => OnColorSelectionChanged(value)); 
        }

        protected override void OnSelectionTglValueChanged(bool isOn) {
            FireOnClothesSelectionChangedEvent();
        }

        public void SetClothes(bool buy, List<Clothes> clothes, Clothes clothesBeingTriedOfThisType) {
            this.buy = buy;
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
            int price = clothes[index].Price;
            if(!buy) {
                price /= 2;
            }
            amountTxt.text = price.ToString("$ #");
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
