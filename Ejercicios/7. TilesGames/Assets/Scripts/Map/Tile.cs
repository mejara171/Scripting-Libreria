using Characters;
using UnityEngine;

namespace Map
{
    public class Tile: MonoBehaviour
    {
        [SerializeField]
        private TerrainType terrain;
        public Character Character { get; set; }
        public float Cost
        {
            get
            {
                //TODO: Get Cost
                return 1f;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return Character != null;
            }
        }
    }
}