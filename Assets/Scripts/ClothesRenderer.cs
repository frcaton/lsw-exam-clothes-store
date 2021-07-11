using UnityEngine;

namespace ClothesStore {
    
    public class ClothesRenderer : MonoBehaviour {

        [SerializeField]
        private BodyPart bodyPart;
        public BodyPart BodyPart => bodyPart;
        
        private SpriteRenderer spriteRenderer;

        private Clothes equippedClothes;
        public Clothes EquippedClothes {
            set {
                equippedClothes = value;                
                spriteRenderer.sprite = equippedClothes == null ? null : equippedClothes.Sprite;
            }            
        }

        private void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

    }

}
