using UnityEngine;

namespace ClothesStore {
    
    public class Item : ScriptableObject {

        [SerializeField]
        private Sprite sprite;
        public Sprite Sprite => sprite;

        [SerializeField]
        private int price;
        public int Price => price;
        
        public virtual string Name => name;

        private bool equipped;
        public bool Equipped {
            get => equipped;
            set => equipped = false;
        }

    }
    
}