using UnityEngine;

namespace SaveCar
{
    public class VehiclesDataAdapter : VehiclesSaveData{
        public VehiclesDataAdapter(Vehicle2 _vehicle, int _id){
            vehicles[_id-1] = new VehicleDataAdapter(_vehicle, _id);
        }
        public static VehicleSaveData VehiclesToVehicle(VehiclesSaveData _vehiclesSaveData, int _id){
            VehicleSaveData vehicle = null;
            foreach (var vehicleIndex in _vehiclesSaveData.vehicles)
            {
                if(vehicleIndex.id == _id){
                    vehicle = vehicleIndex;
                    break;
                }
            }
            return vehicle;
        }
    }
}