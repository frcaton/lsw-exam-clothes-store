using UnityEngine;
using UnityEngine.Tilemaps;

using Mimic;

namespace ClothesStore {

    public class GameManager : Singleton<GameManager> {

        [SerializeField]
        private int money;
        public int Money {
            get => money;
            set => money = Mathf.Max(0, value);
        }

        [SerializeField]
        private Tilemap world;
        public Tilemap World => world;

    }
    
}