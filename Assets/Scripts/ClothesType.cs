using UnityEngine;

namespace ClothesStore {

    [CreateAssetMenu(fileName = "Clothes Type", menuName = "Clothes/Clothes Type", order = 0)]
    
    public class ClothesType : ScriptableObject {

        [SerializeField]
        private BodyPart bodyPart;
        public BodyPart BodyPart => bodyPart;

    }

}
