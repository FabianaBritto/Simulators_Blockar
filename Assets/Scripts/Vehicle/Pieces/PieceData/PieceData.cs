using UnityEngine;
using Block;
using System.Collections.Generic;

// [CreateAssetMenu(fileName = "PieceData", menuName = "Pieces/PieceData", order = 1)]
public class PieceData : ScriptableObject
{
    [Tooltip("The Pieces of the game")]
    [SerializeField] private List<GameObject> pieces;

    public GameObject FindPiece(string pieceName){
        GameObject obj = null;
        foreach (GameObject piece in pieces)
        {
            BlockBehavior block;
            if(piece.TryGetComponent<BlockBehavior>(out block))
                if (block.settings.label == pieceName)
                    obj = piece;
        }
        return obj;
    }


}
