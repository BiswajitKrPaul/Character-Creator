using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Farming_Code {
    public class TileMapManager : MonoBehaviour {
        [SerializeField] private Tilemap farmingTileMapLayer;
        [SerializeField] private TileData growBlockTileData;
        [SerializeField] private TileBase ploughedTile;
        [SerializeField] private TileBase wateredTile;

        [SerializeField] private Tile nonVisibleInteractiveTile;

        private readonly Dictionary<Vector3Int, TileData> farmTileData = new Dictionary<Vector3Int, TileData>();

        public static TileMapManager Instance { get; private set; }

        private void Awake() {
            if (Instance == null)
                Instance = this;

            // //This is done to make the tile transparency to visible
            // nonVisibleInteractiveTile.color = new Color32(255, 255, 255, 255);
        }

        private void Start() {
            var tileMapBounds = farmingTileMapLayer.cellBounds;

            foreach (var position in tileMapBounds.allPositionsWithin) {
                var tile = farmingTileMapLayer.GetTile(position);
                if (tile == null) continue;
                var newGrowBlockInstance = ScriptableObject.CreateInstance<TileData>();
                newGrowBlockInstance.stage = TileStage.Blank;
                newGrowBlockInstance.canPlantSeeds = true;
                farmingTileMapLayer.SetTile(position, nonVisibleInteractiveTile);
                farmTileData.Add(position, newGrowBlockInstance);
            }
        }

        public Vector3Int GetWorldToCellPosition(Vector3 worldPosition) {
            return farmingTileMapLayer.WorldToCell(worldPosition);
        }

        public TileData GetTileData(Vector3Int position) {
            return farmTileData.GetValueOrDefault(position);
        }

        public void SetFarmingTile(Vector3Int position) {
            var tileData = GetTileData(position);
            if (tileData is null) return;
            if (tileData.canPlantSeeds && tileData.stage == TileStage.Blank) {
                farmingTileMapLayer.SetTile(position, ploughedTile);
                farmTileData[position].stage = TileStage.Ploughed;
            }
            else if (tileData.stage == TileStage.Ploughed) {
                farmingTileMapLayer.SetTile(position, wateredTile);
                farmTileData[position].stage = TileStage.Watered;
            }
        }
    }
}