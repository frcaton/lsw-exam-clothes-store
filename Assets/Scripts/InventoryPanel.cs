using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class InventoryPanel : MonoBehaviour {

        [SerializeField]
        private RectTransform listParent;

        [SerializeField]
        private InventoryPanelListItem listItemPrefab;

        [SerializeField]
        private EquipPreviewPanel equipPreviewPnl;

        public void Show() {
            gameObject.SetActive(true);
            equipPreviewPnl.Clear();

            Inventory inventory = GameManager.Instance.Player.Inventory;
            
            int i = 0;
            InventoryPanelListItem item;
            inventory.Slots.ForEach(slot => {
                if(i < listParent.childCount) {
                    item = listParent.GetChild(i).GetComponent<InventoryPanelListItem>();
                    item.gameObject.SetActive(true);
                } else {
                    item = Instantiate<InventoryPanelListItem>(listItemPrefab, listParent);
                }
                item.Set(this, slot);
            });

            while(i < listParent.childCount) {
                listParent.GetChild(i++).gameObject.SetActive(false);
            }
        }

        public void OnEquip(Item item) {
            if(item is Clothes itemAsClothes) {
                InventoryPanelListItem listItem;
                for (int i = 0; i < listParent.childCount; i++) {
                    listItem = listParent.GetChild(i).GetComponent<InventoryPanelListItem>();
                    if(listItem.Item != item && listItem.Item is Clothes clothes) {
                        if(clothes.BodyPart == itemAsClothes.BodyPart) {
                            listItem.IsSelected = false;
                        }
                    }
                }
                GameManager.Instance.Player.Equip(itemAsClothes);
            }
        }

        public void OnCloseBtnClick() {
            gameObject.SetActive(false);
            GameManager.Instance.IsPaused = false;
        }

    }

}
