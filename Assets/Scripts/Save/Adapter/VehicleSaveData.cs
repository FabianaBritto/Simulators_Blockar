using UnityEngine;
using System;

namespace SaveCar
{
    [Serializable]
    public class VehicleSaveData
    {
        public int id;
        public PieceSaveData[] pieces;
    }
}