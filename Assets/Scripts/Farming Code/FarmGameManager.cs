using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Farming_Code {
    public class FarmGameManager : MonoBehaviour {
        public Camera cam;

        private void Update() {
            if (!Input.GetMouseButtonDown(0)) return;
            var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            var tileManager = TileMapManager.Instance;
            var tilePosition = tileManager.GetWorldToCellPosition(mousePosition);
            var tileData = tileManager.GetTileData(tilePosition);
            if (tileData is not null && tileData.canPlantSeeds) {
                tileManager.SetFarmingTile(tilePosition);
            }
        }
    }
}