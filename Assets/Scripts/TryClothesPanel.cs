using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ClothesStore {
    
    public class TryClothesPanel : MonoBehaviour {

        [SerializeField]
        private List<TryClothesImage> tryImgs;

        private List<Clothes> clothesBeingTried;
        public List<Clothes> ClothesBeingTried => clothesBeingTried;

        /// <summary>
        /// Show the clothes in the preview
        /// </summary>
        /// <returns>the total price of all clothes being tried</returns>
        public int Try(Clothes clothes) {
            tryImgs.Find(img => img.BodyPart == clothes.Type.BodyPart).TryImg.sprite = clothes.Sprite;

            int totalPrice = clothes.Price;
            for (int i = 0; i < clothesBeingTried.Count; i++) {
                if(clothesBeingTried[i].Type.BodyPart == clothes.Type.BodyPart) {
                    clothesBeingTried.RemoveAt(i--);
                } else {
                    totalPrice += clothes.Price;
                }
            }
            clothesBeingTried.Add(clothes);

            return totalPrice; 
        }

        /// <summary>
        /// Removes the clothes in the preview
        /// </summary>
        /// <returns>the total price of all clothes being tried</returns>
        public int Remove(Clothes clothes) {
            tryImgs.Find(img => img.BodyPart == clothes.Type.BodyPart).TryImg.sprite = null;

            int totalPrice = 0;
            for (int i = 0; i < clothesBeingTried.Count; i++) {
                if(clothesBeingTried[i] == clothes) {
                    clothesBeingTried.RemoveAt(i--);
                } else {
                    totalPrice += clothes.Price;
                }
            }

            return totalPrice; 
        }

    }

}
