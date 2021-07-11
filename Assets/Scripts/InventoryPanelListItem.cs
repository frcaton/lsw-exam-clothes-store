using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class InventoryPanelListItem : ListItem {
        
        private InventorySlot slot;
        public Item Item => slot.Item;

        private InventoryPanel inventoryPnl;

        protected override void OnSelectionTglValueChanged(bool isOn) {
            if(isOn) {
                inventoryPnl.OnEquip(slot.Item);
            } else if(Item is Clothes clothes) {
                GameManager.Instance.Player.ClearEquipment(clothes.BodyPart);
            }
        }

        public void Set(InventoryPanel inventoryPnl, InventorySlot slot) {
            this.inventoryPnl = inventoryPnl;
            this.slot = slot;
            icon.sprite = slot.Item.Sprite;
            nameTxt.text = slot.Item.name;
            selectionTgl.isOn = slot.Item.Equipped;
            amountTxt.text = slot.Amount.ToString();
        }

    }

}
