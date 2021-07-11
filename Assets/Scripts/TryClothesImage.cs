using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class TryClothesImage : MonoBehaviour {

        [SerializeField]
        private Image tryImg;
        public Image TryImg => tryImg;

        [SerializeField]
        private BodyPart bodyPart;
        public BodyPart BodyPart => bodyPart;

    }

}
