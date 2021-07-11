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

        private List<Clothes> clothes;
        public List<Clothes> Clothes {
            get => clothes;
            set {
                clothes = value;

                colorDrpDwn.ClearOptions();

                List<Dropdown.OptionData> options = new List<Dropdown.OptionData>(clothes.Count);
                clothes.ForEach(c => options.Add(new Dropdown.OptionData(c.Color.ToString())));

                colorDrpDwn.AddOptions(options);
                colorDrpDwn.value = 0;

                nameTxt.text = clothes[0].Type.name;
            }
        }

        private void Awake() {
            selectionTgl = GetComponent<Toggle>();
            selectionTgl.isOn = false;
            colorDrpDwn.onValueChanged.AddListener(value => OnColorSelectionChanged(value)); 
        }

        private void OnColorSelectionChanged(int index) {
            icon.sprite = clothes[index].Sprite;
            priceTxt.text = clothes[index].Price.ToString("$ #");
        }

    }

}
