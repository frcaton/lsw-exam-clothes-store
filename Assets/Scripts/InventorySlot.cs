using System;

using UnityEngine;

namespace ClothesStore {

    [Serializable]
    public class InventorySlot {

        [SerializeField]
        private Item item;
        public Item Item => item;

        [SerializeField]
        private int amount;
        public int Amount {
            get => amount;
            set => amount = Mathf.Max(value, 0);
        }

        public InventorySlot(Item item, int amount) {
            this.item = item;
            this.amount = amount;
        }

        /// <summary>
        /// Adds an amount to the slot
        /// </summary>
        /// <returns>Returns the amount of the item in the slot after the operation</returns>
        public int Add(int amount) {
            return Amount += amount;
        }

        /// <summary>
        /// Removes an amount from the slot
        /// </summary>
        /// <returns>Returns the amount of the item in the slot after the operation</returns>
        public int Remove(int amount) {
            return Amount -= amount;
        }

    }
    
}