using UnityEngine;

namespace SaveCar{
    public class PieceDataAdapter : PieceSaveData
    {
        public PieceDataAdapter(GameObject piece){
            Block.BlockBehavior block;
            if(piece.TryGetComponent<Block.BlockBehavior>(out block))
                name = block.settings.label;
            else
                name = "";
            // for (var i = 0; i < piece.name.Length-7; i++)
            // {
            //     _name += piece.name[i];
            // }
            position = piece.transform.position;
            rotation = piece.transform.eulerAngles;
        }
    }
}