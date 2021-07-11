using System;
using System.Collections.Generic;

using UnityEngine;

namespace ClothesStore {

    [Serializable]
    public class Inventory {

        [SerializeField]
        private List<InventorySlot> slots;
        public List<InventorySlot> Slots => slots;

        private PlayerController owner;
        public PlayerController Owner {
            set => owner = value;
        }

        public InventorySlot GetSlot(Item item) {
            return slots.Find(slot => slot.Item == item);
        }

        /// <summary>
        /// Adds an amount of items to the inventory
        /// </summary>
        /// <returns>The amount of the item in the inventory after the operation</returns>
        public int Add(Item item, int amount) {
            InventorySlot slot = GetSlot(item);
            if(slot == null) {
                slot = new InventorySlot(item, amount);
                slots.Add(slot);
                return amount;
            } else {
                return slot.Add(amount);
            }
        }

        /// <summary>
        /// Removes an amount of items from the inventory
        /// </summary>
        /// <returns>The amount of the item in the inventory after the operation</returns>
        public int Remove(Item item, int amount) {
            InventorySlot slot = GetSlot(item);
            if(slot != null) {
                int amountLeft = slot.Remove(amount);
                if(amountLeft == 0) {
                    slots.Remove(slot);
                    if(item.Equipped) {
                        item.Equipped = false;
                        if(item is Clothes clothes) {
                            owner.ClearEquipment(clothes.BodyPart);
                        }
                    }
                }
                return amountLeft;
            } else {
                return 0;
            }
        }

    }
    
}