using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CharacterCustomizer : MonoBehaviour {
    private static readonly int XAxis = Animator.StringToHash("xAxis");

    private static readonly int YAxis = Animator.StringToHash("yAxis");

    //Sprite Library Assets
    [SerializeField] private List<SpriteLibraryAsset> bodySpriteList;
    [SerializeField] private List<SpriteLibraryAsset> hairSpriteList;
    [SerializeField] private List<SpriteLibraryAsset> outfitsSpriteList;


    //Sprite Library
    [SerializeField] private SpriteLibrary bodySpriteLibrary;
    [SerializeField] private SpriteLibrary hairSpriteLibrary;
    [SerializeField] private SpriteLibrary outfitSpriteLibrary;

    //Selected Index
    [SerializeField] private int bodyIndex;
    [SerializeField] private int hairIndex;
    [SerializeField] private int outfitIndex;
    private Animator _animator;


    //Rotate Sprite
    private Vector2Int _direction = Vector2Int.down;


    private void Start() {
        _animator = GetComponent<Animator>();
        SyncWithSaveData();
    }


    private void Update() {
        UpdateAnimations();
    }

    private void SyncWithSaveData() {
        bodyIndex = GameManager.Instance.PlayerData.bodyIndex;
        hairIndex = GameManager.Instance.PlayerData.hairIndex;
        outfitIndex = GameManager.Instance.PlayerData.outfitIndex;
        bodySpriteLibrary.spriteLibraryAsset = bodySpriteList[bodyIndex];
        hairSpriteLibrary.spriteLibraryAsset = hairSpriteList[hairIndex];
        outfitSpriteLibrary.spriteLibraryAsset = outfitsSpriteList[outfitIndex];
    }

    private void UpdateAnimations() {
        _animator.SetFloat(XAxis, _direction.x);
        _animator.SetFloat(YAxis, _direction.y);
    }

    private void UpdateCharacterIndex() {
        GameManager.Instance.PlayerData.hairIndex = hairIndex;
        GameManager.Instance.PlayerData.bodyIndex = bodyIndex;
        GameManager.Instance.PlayerData.outfitIndex = outfitIndex;
    }

    public void UpDirection() {
        _direction = Vector2Int.up;
    }

    public void DownDirection() {
        _direction = Vector2Int.down;
    }

    public void LeftDirection() {
        _direction = Vector2Int.left;
    }

    public void RightDirection() {
        _direction = Vector2Int.right;
    }


    public void SetBodySpriteIndex() {
        bodyIndex = (bodyIndex + 1) % bodySpriteList.Count;
        bodySpriteLibrary.spriteLibraryAsset = bodySpriteList[bodyIndex];
        UpdateCharacterIndex();
    }

    public void SetHairSpriteIndex() {
        hairIndex = (hairIndex + 1) % hairSpriteList.Count;
        hairSpriteLibrary.spriteLibraryAsset = hairSpriteList[hairIndex];
        UpdateCharacterIndex();
    }

    public void SetOutfitSpriteIndex() {
        outfitIndex = (outfitIndex + 1) % outfitsSpriteList.Count;
        outfitSpriteLibrary.spriteLibraryAsset = outfitsSpriteList[outfitIndex];
        UpdateCharacterIndex();
    }

    public void SaveCharacterData() {
        GameManager.Instance.SaveGameDate();
    }
}