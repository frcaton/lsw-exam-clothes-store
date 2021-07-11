using UnityEngine;

namespace ClothesStore {
    
    public class Item : ScriptableObject {

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;

        [SerializeField]
        private int price;
        public int Price => price;
        
        public virtual string Name => name;

        private bool equipped;
        public bool Equipped {
            get => equipped;
            set => equipped = value;
        }

    }
    
}