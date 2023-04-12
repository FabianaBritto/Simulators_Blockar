using UnityEngine;
using System;

namespace SaveCar
{
    [Serializable]
    public class VehiclesSaveData
    {
        public VehicleSaveData[] vehicles = new VehicleSaveData[6];
    }
}