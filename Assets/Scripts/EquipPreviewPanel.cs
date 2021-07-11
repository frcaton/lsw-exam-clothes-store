using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class EquipPreviewPanel : MonoBehaviour {

        [SerializeField]
        private List<EquipPreviewImage> previewImgs;

        private List<Clothes> clothesBeingPreviewed = new List<Clothes>();
        public List<Clothes> ClothesBeingPreviewed => clothesBeingPreviewed;

        /// <summary>
        /// Show the clothes in the preview
        /// </summary>
        /// <returns>the total price of all clothes being previewed</returns>
        public int Try(Clothes clothes) {
            EquipPreviewImage equipPreviewImg = previewImgs.Find(img => img.BodyPart == clothes.Type.BodyPart);
            equipPreviewImg.PreviewImg.sprite = clothes.Sprite;
            equipPreviewImg.gameObject.SetActive(true);

            int totalPrice = clothes.Price;
            for (int i = 0; i < clothesBeingPreviewed.Count; i++) {
                if(clothesBeingPreviewed[i].Type.BodyPart == clothes.Type.BodyPart) {
                    clothesBeingPreviewed.RemoveAt(i--);
                } else {
                    totalPrice += clothesBeingPreviewed[i].Price;
                }
            }
            clothesBeingPreviewed.Add(clothes);

            return totalPrice; 
        }

        /// <summary>
        /// Removes the clothes in the preview
        /// </summary>
        /// <returns>the total price of all clothes being previewed</returns>
        public int Remove(Clothes clothes) {
            previewImgs.Find(img => img.BodyPart == clothes.Type.BodyPart).gameObject.SetActive(false);

            int totalPrice = 0;
            for (int i = 0; i < clothesBeingPreviewed.Count; i++) {
                if(clothesBeingPreviewed[i] == clothes) {
                    clothesBeingPreviewed.RemoveAt(i--);
                } else {
                    totalPrice += clothesBeingPreviewed[i].Price;
                }
            }

            return totalPrice; 
        }
        
        /// <summary>
        /// Removes the clothes for a body part in the preview
        /// </summary>
        /// <returns>the total price of all clothes being previewed</returns>
        public int Clear(BodyPart bodyPart) {
            previewImgs.Find(img => img.BodyPart == bodyPart).gameObject.SetActive(false);

            int totalPrice = 0;
            for (int i = 0; i < clothesBeingPreviewed.Count; i++) {
                if(clothesBeingPreviewed[i].BodyPart == bodyPart) {
                    clothesBeingPreviewed.RemoveAt(i--);
                } else {
                    totalPrice += clothesBeingPreviewed[i].Price;
                }
            }

            return totalPrice; 
        }

        public void Clear() {
            previewImgs.ForEach(img => img.gameObject.SetActive(false));
            clothesBeingPreviewed.Clear();
        }

        public Clothes GetClothesBeingPreviewed(ClothesType type) {
            return clothesBeingPreviewed.Find(clothes => clothes.Type == type);
        }

    }

}
