using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour {
    private string _GetFilePath() {
        var saveFilePath = Application.persistentDataPath + "/player.json";
        return saveFilePath;
    }

    public void SaveGame(PlayerData playerData) {
        var json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(_GetFilePath(), json);
        Debug.Log("Game Saved to: " + _GetFilePath());
    }

    // Load the data from a JSON file
    public PlayerData LoadGame() {
        if (File.Exists(_GetFilePath())) {
            var json = File.ReadAllText(_GetFilePath());
            var playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game Loaded from: " + _GetFilePath());
            return playerData;
        }

        Debug.LogWarning("Save file not found!");
        return null;
    }
}