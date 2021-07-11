using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class StorePanel : MonoBehaviour {

        [SerializeField]
        private Sprite saleswomanIcn;

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
        private EquipPreviewPanel equipPreviewPnl;

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

        private bool buy;

        public int TotalPrice {
            get {
                int price = 0;
                equipPreviewPnl.ClothesBeingPreviewed.ForEach(clothes => price += clothes.Price);
                return buy ? price : price / 2;
            }
        }

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
            this.buy = buy;
            gameObject.SetActive(true);
            ClearSelection();
            categoryBtns[0].IsSelected = true;
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
                    item.SetClothes(buy, clothesGroupedByType[type], equipPreviewPnl.GetClothesBeingPreviewed(type));
                }   
            }

            while(i < listParent.childCount) {
                listParent.GetChild(i++).gameObject.SetActive(false);
            }
        }

        private void OnClothesSelectionChanged(Clothes selection) {
            int totalPrice;
            if(selection == null) {
                totalPrice = equipPreviewPnl.Clear(selectedCategory);
            } else {
                totalPrice = equipPreviewPnl.Try(selection);
            }
            if(!buy) {
                totalPrice /= 2;
            }
            totalPriceTxt.text = totalPrice.ToString("$ #");
        }

        public void OnBuyBtnClick() {
            if(GameManager.Instance.Money < TotalPrice) {
                MessagePanel.Instance.Show(saleswomanIcn, "I'm sorry you don't have enough money", "Ok", null);
            } else {
                MessagePanel.Instance.Show(saleswomanIcn, $"Are you sure you want to buy?{System.Environment.NewLine}It will cost you {totalPriceTxt.text}", "Ok", "Cancel", OnBuyConfirmed, null);
            }
        }

        private void OnBuyConfirmed() {
            GameManager.Instance.OnClothesBought(equipPreviewPnl.ClothesBeingPreviewed);    
            ClearSelection();        
        }

        public void OnSellBtnClick() {
            GameManager.Instance.OnClothesSold(equipPreviewPnl.ClothesBeingPreviewed);    
            ClearSelection();
        }

        private void ClearSelection() {
            for (int i = 0; i < listParent.childCount; i++) {
                listParent.GetChild(i).GetComponent<ClothesListItem>().IsSelected = false;
            }
            equipPreviewPnl.Clear();
            totalPriceTxt.text = "$ 0";
        }

        public void OnCloseBtnClick() {
            gameObject.SetActive(false);
            GameManager.Instance.IsPaused = false;
        }

    }

}
