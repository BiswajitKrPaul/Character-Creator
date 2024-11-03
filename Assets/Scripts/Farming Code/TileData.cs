using UnityEngine;

namespace Farming_Code {
    [CreateAssetMenu(fileName = "New TileData", menuName = "2D/Tiles/Tile Data")]
    public class TileData : ScriptableObject {
        public bool canPlantSeeds;
        public TileStage stage = TileStage.Blank;
    }


    public enum TileStage {
        Blank,
        Ploughed,
        Watered
    }
}