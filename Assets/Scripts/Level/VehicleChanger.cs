using System.Collections;
using Audio;
using UnityEngine;

public class VehicleChanger : MonoBehaviour
{
    [SerializeField] private GameObject vehicleObject;
    public GameObject VehicleObject{
        get{return vehicleObject;}
        set{vehicleObject = value;}
    }
    [SerializeField] private GameObject[] vehicles;

    private VFXManager vfxManager;

    private void Start()
    {
         Tutorial.Instance.EnableTutorial(false);
        //AudioManager.Instance.Stop("Motor");
        vfxManager = GetComponent<VFXManager>();
        if(GameManager.instance)
            vehicles[0] = GameManager.instance.GetVehicle;
        
        int vehicleId = VehicleHelper.Vehicle;
        TutorialEnable(vehicleId);
        StartCoroutine(WaitToBlocksAnimationsOver(vehicleId));
    }
    
    IEnumerator WaitToBlocksAnimationsOver(int id)
    {
        yield return new WaitForSeconds(1.5f);
        InstantiateVehicle(id);
    }
    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Alpha1)) InstantiateVehicle(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) InstantiateVehicle(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) InstantiateVehicle(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) InstantiateVehicle(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) InstantiateVehicle(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) InstantiateVehicle(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) InstantiateVehicle(6);
        if (Input.GetKeyDown(KeyCode.Alpha8)) InstantiateVehicle(7);
        if (Input.GetKeyDown(KeyCode.Alpha9)) InstantiateVehicle(8);
        if (Input.GetKeyDown(KeyCode.Alpha0)) InstantiateVehicle(9);
        if (Input.GetKeyDown(KeyCode.Q)) InstantiateVehicle(10);
        if (Input.GetKeyDown(KeyCode.W)) InstantiateVehicle(11);
        if (Input.GetKeyDown(KeyCode.E)) InstantiateVehicle(12);        
        if (Input.GetKeyDown(KeyCode.T)) InstantiateVehicle(13);
        if (Input.GetKeyDown(KeyCode.Y)) InstantiateVehicle(14);
        if (Input.GetKeyDown(KeyCode.U)) InstantiateVehicle(15);
        if (Input.GetKeyDown(KeyCode.I)) InstantiateVehicle(16);
        if (Input.GetKeyDown(KeyCode.O)) InstantiateVehicle(17);
        if (Input.GetKeyDown(KeyCode.P)) InstantiateVehicle(18);
        if (Input.GetKeyDown(KeyCode.A)) InstantiateVehicle(19);
        if (Input.GetKeyDown(KeyCode.S)) InstantiateVehicle(20);*/
    }

    private void InstantiateVehicle(int vehicleId)
    {
        if (vehicleObject) Destroy(vehicleObject);

        Vector3 position = new(0, 1, 0);
        vfxManager.EnableVFX("CFX3_Hit_SmokePuff");
        vehicleObject = Instantiate(vehicles[vehicleId], position, Quaternion.identity);
        VehicleHelper.Vehicle = vehicleId;
        //TutorialEnable(vehicleId);
    }

    void TutorialEnable(int id)
    {
        Tutorial.Instance.EnableTutorial(false);
        if(vehicles[id].name != "Vehicle_16") return;
        Tutorial.Instance.EnableTutorial(true);
    }
}
