using UnityEngine;

namespace ClothesStore {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private Inventory inventory;
        public Inventory Inventory => inventory;

        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }   

    }
    
}