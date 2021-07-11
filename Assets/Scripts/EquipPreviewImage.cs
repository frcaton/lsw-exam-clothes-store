using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class EquipPreviewImage : MonoBehaviour {

        [SerializeField]
        private Image previewImg;
        public Image PreviewImg => previewImg;

        [SerializeField]
        private BodyPart bodyPart;
        public BodyPart BodyPart => bodyPart;

    }

}
