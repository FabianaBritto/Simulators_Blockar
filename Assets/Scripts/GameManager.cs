using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Block;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public enum BlockType{Block, Wheel, Engine}
    [SerializeField] private BlockBehavior.Types currentPieceType;

    #region GameObjects
    [SerializeField]private GameObject pieceToCreate;
    [SerializeField]private GameObject selectedBlock;
    [SerializeField]private GameObject placeHolder;
    [SerializeField]private GameObject mainBlock;
    [SerializeField]private GameObject vehicle;
    #endregion

    #region Controls
    [Header("Booleans")]
    [SerializeField] private bool isEditing = false;
    [SerializeField] private bool canDestroy = false;
    [SerializeField] private bool canCreate = false;
    #endregion

    #region Lists
    // [SerializeField] private List<GameObject> pieces;
    // [SerializeField] private List<Engine> engines;
    [SerializeField] private List<WheelCollider> wheelColliders;
    #endregion

    [SerializeField] private PieceData pieceData;
    // [SerializeField] private PlaceHoldersData placeHoldersData;

    void Awake(){
        // instance = this;
        if (instance) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start(){
        SetSelectedBlock(GetMainBlock);
    }


    // #region CurrentBlockType
    // public BlockType GetCurrentBlockType => currentBlockType;
    // public void SetCurrentBlockType(BlockType type){
    //     currentBlockType = type;
    // }
    // #endregion

    #region CurrentBlockType
    public BlockBehavior.Types GetCurrentPieceType => pieceToCreate.GetComponent<BlockBehavior>().type;
    public void SetCurrentPieceType(BlockBehavior.Types type){
        currentPieceType = type;
    }
    #endregion

    #region GameObjects

    #region PieceToCreate
    public GameObject GetPieceToCreate => pieceToCreate;
    public void SetPieceToCreate(string blockName){
        // selectedBlock = block;
        pieceToCreate = pieceData.FindPiece(blockName);
    }
    #endregion
    
    #region PlaceHolder
    public GameObject GetPlaceHolder => placeHolder;
    public void SetPlaceHolder(string blockName){
        placeHolder = PlaceHoldersData.instance.FindPlaceHolder(blockName);
    }
    #endregion

    #region SelectedBlock
    public GameObject GetSelectedBlock(){
        if (selectedBlock == null)
        {
            SetSelectedBlock(GetMainBlock);
        }
        return selectedBlock;
    }
    public void SetSelectedBlock(GameObject block){
        selectedBlock = block;
    }
    #endregion

    #region MainBlock
    public GameObject GetMainBlock => mainBlock;
    #endregion

    #region  Vehicle
    public GameObject GetVehicle => vehicle;
    #endregion

    #endregion

    #region Controls

    #region IsEditing
    public bool GetIsEditing => isEditing;
    public void SetIsEditing(bool set)
    {
        isEditing = set;
    }
    #endregion

    #region CanDestroy
    public bool GetCanDestroy => canDestroy;
    public void SetCanDestroy(bool set)
    {
        canDestroy = set;
    }
    #endregion

    #region CanCreate
    public bool GetCanCreate => canCreate;
    public void SetCanCreate(bool set)
    {
        canCreate = set;
    }
    #endregion

    #endregion

    #region Lists
    // public List<GameObject> GetPieces => pieces;
    // public void AddBlock(Block block){
    //     blocks.Add(block);
    // }
    // public List<Engine> GetEngines => engines;
    // public void AddEngine(Engine engine){
    //     engines.Add(engine);
    // }
    public List<WheelCollider> GetWheelColliders => wheelColliders;
    public void AddWheelCollider(WheelCollider wheelCollider){
        wheelColliders.Add(wheelCollider);
    }
    #endregion
}
