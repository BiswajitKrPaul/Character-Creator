using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    [SerializeField] private SaveSystem saveSystem;

    public PlayerData PlayerData { get; private set; }


    private void Awake() {
        Instance = this;
        PlayerData = saveSystem.LoadGame() ?? new PlayerData {
            bodyIndex = 0,
            hairIndex = 0,
            outfitIndex = 0
        };
    }

    public void SaveGameDate() {
        saveSystem.SaveGame(PlayerData);
    }
}

[Serializable]
public class PlayerData {
    public int bodyIndex;
    public int hairIndex;
    public int outfitIndex;
}