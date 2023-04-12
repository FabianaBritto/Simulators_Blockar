using UnityEngine;
using System;

namespace SaveCar
{
    [Serializable]
    public class PieceSaveData
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;
    }
}