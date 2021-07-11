using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class StorePanel : MonoBehaviour {

        [SerializeField]
        private Text titleTxt;

        [SerializeField]
        private List<CategoryToggle> categoryBtns;

        [SerializeField]
        private RectTransform listParent;

        [SerializeField]
        private ClothesListItem listItemPrefab;

        [SerializeField]
        private ToggleGroup itemsTglGrp;

        [SerializeField]
        private TryClothesPanel tryPnl;

        [SerializeField]
        private Text totalPriceTxt;

        [SerializeField]
        private Button buyBtn;

        [SerializeField]
        private Button sellBtn;

        [SerializeField]
        private string buyTitle;

        [SerializeField]
        private string sellTitle;

        [SerializeField]
        private List<Clothes> stock;

        private Dictionary<ClothesType, List<Clothes>> clothesGroupedByType = new Dictionary<ClothesType, List<Clothes>>();

        private BodyPart selectedCategory;

        private void Awake() {
            categoryBtns.ForEach(categoryBtn => {
                categoryBtn.OnSelected = OnCategorySelected;
                if(categoryBtn.IsSelected) {
                    selectedCategory = categoryBtn.BodyPart;
                }
            });

            stock.ForEach(clothes => {
                List<Clothes> clothesOfType;
                if(clothesGroupedByType.ContainsKey(clothes.Type)) {
                    clothesOfType = clothesGroupedByType[clothes.Type];
                } else {
                    clothesOfType = new List<Clothes>();
                    clothesGroupedByType.Add(clothes.Type, clothesOfType);
                }
                clothesOfType.Add(clothes);
            });
        }

        public void Show(bool buy) {
            gameObject.SetActive(true);
            if(buy) {
                titleTxt.text = buyTitle;
                buyBtn.gameObject.SetActive(true);
                sellBtn.gameObject.SetActive(false);
            } else {
                titleTxt.text = sellTitle;
                buyBtn.gameObject.SetActive(false);
                sellBtn.gameObject.SetActive(true);
            }
        }

        private void OnCategorySelected(BodyPart bodyPart) {
            this.selectedCategory = bodyPart;
            int i = 0;
            ClothesListItem item;

            foreach(ClothesType type in clothesGroupedByType.Keys) {
                if(type.BodyPart == bodyPart) {
                    if(i < listParent.childCount) {
                        item = listParent.GetChild(i).GetComponent<ClothesListItem>();
                        item.gameObject.SetActive(true);
                    } else {
                        item = Instantiate<ClothesListItem>(listItemPrefab, listParent);
                        item.OnClothesSelectionChanged = OnClothesSelectionChanged;
                        item.Group = itemsTglGrp;
                    }
                    i++;
                    item.SetClothes(clothesGroupedByType[type], tryPnl.GetClothesBeingTried(type));
                }   
            }

            while(i < listParent.childCount) {
                listParent.GetChild(i++).gameObject.SetActive(false);
            }
        }

        private void OnClothesSelectionChanged(Clothes selection) {
            int totalPrice;
            if(selection == null) {
                totalPrice = tryPnl.Clear(selectedCategory);
            } else {
                totalPrice = tryPnl.Try(selection);
            }
            totalPriceTxt.text = totalPrice.ToString("$ #");
        }

        public void OnBuyBtnClick() {

        }

        public void OnSellBtnClick() {

        }

        public void OnCloseBtnClick() {
            gameObject.SetActive(false);
        }

    }

}
