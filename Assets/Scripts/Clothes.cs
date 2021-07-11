using UnityEngine;

namespace ClothesStore {
    
    [CreateAssetMenu(fileName = "Clothes Type", menuName = "Clothes/Clothes", order = 1)]
    public class Clothes : Item {

        [SerializeField]
        private ClothesType type;
        public ClothesType Type => type;
        
        public BodyPart BodyPart => type.BodyPart;

        [SerializeField]
        private ClothesColor color;
        public ClothesColor Color => color;

        [SerializeField]
        private Sprite sprite;
        public Sprite Sprite => sprite;

    }

}
