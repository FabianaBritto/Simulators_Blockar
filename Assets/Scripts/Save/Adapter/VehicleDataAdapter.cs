using UnityEngine;

namespace SaveCar{
    public class VehicleDataAdapter : VehicleSaveData
    {
        public VehicleDataAdapter(Vehicle2 _vehicle, int _id){
            PieceSaveData[] _pieces = new PieceSaveData[_vehicle.Pieces.Count];
            for (var i = 0; i < _pieces.Length; i++)
            {
                _pieces[i] = new PieceDataAdapter(_vehicle.Pieces[i]);
            }
            id = _id;
            pieces = _pieces;
        }
    }
}