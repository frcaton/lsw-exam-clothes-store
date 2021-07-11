using UnityEngine;

namespace ClothesStore {
    
    public class Item : ScriptableObject {

        [SerializeField]
        private int price;
        public int Price => price;

    }
    
}