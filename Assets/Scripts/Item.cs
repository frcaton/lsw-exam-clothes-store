using UnityEngine;

namespace ClothesStore {
    
    public class Item : MonoBehaviour {

        [SerializeField]
        private int price;
        public int Price => price;

    }
    
}