using System.IO;
using UnityEngine;

namespace SaveCar
{
    public class SaveManager {
        private static VehiclesSaveData vehicleSave = null;
        private static string saveCarPath = Application.persistentDataPath + "/saveCar.json";
        public static void Save(Vehicle2 vehicle, int id){
            if (vehicleSave == null)
            {
                vehicleSave = new VehiclesDataAdapter(vehicle, id);
            }
            else
            {
                vehicleSave.vehicles[id-1] = new VehicleDataAdapter(vehicle, id);
            }
            string s = JsonUtility.ToJson(vehicleSave);
            try
            {
                File.WriteAllText(saveCarPath,s);
                Debug.Log("Salvo com Sucesso!");
            }
            catch (System.Exception ex)
            {
                Debug.Log($"Impossivel salvar erro:{ex.Message}");
                throw;
            }
        }
        public static PieceSaveData[] Load(int _id, PieceData pieceData){
            PieceSaveData[] _pieces = new PieceSaveData[0];
            if (File.Exists(saveCarPath))
            {
                VehicleSaveData _vehicleSaveData = VehiclesDataAdapter.VehiclesToVehicle(vehicleSave, _id);

                if (_vehicleSaveData != null)
                {
                    // _vehicleSaveData.pieces
                    _pieces = new PieceSaveData[_vehicleSaveData.pieces.Length];
                    for (var i = 0; i < _pieces.Length; i++)
                    {
                        _pieces[i] = _vehicleSaveData.pieces[i];
                    }
                }
                else
                {
                    Debug.Log($"Impossivel carregar veiculo não encontrado");
                }
            
            }
            return _pieces;
        }
        public static void LoadJSON(){
            if (File.Exists(saveCarPath))
            {
                try
                {
                    string s = File.ReadAllText(saveCarPath);
                    vehicleSave = JsonUtility.FromJson<VehiclesSaveData>(s);
                }
                catch (System.Exception ex)
                {
                    Debug.Log($"Impossivel ler erro:{ex.Message}");
                    throw;
                }
            }
        }
    }
    
}