using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine.SceneManagement;
using UnityEngine;
using AutoPilot;
public class EditModeLevelController : MonoBehaviour
{
    public static EditModeLevelController instance;
    public string currentScene;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start() {
    }
    private void Update() {
        if (SceneManager.GetActiveScene().name != "SampleCarCreation" && currentScene != SceneManager.GetActiveScene().name)
        {
            currentScene = SceneManager.GetActiveScene().name;
        }
        // if (Input.GetKeyDown(KeyCode.C) && SceneManager.GetActiveScene().name != "SampleCarCreation")
        // {
        //     if (GameManager.instance)
        //     {
        //         GameManager.instance.GetVehicle.transform.position = new Vector3(0,0,0);
        //         Vehicle2 vehicleScript;
        //         if (GameManager.instance.GetVehicle.TryGetComponent<Vehicle2>(out vehicleScript)){
        //             vehicleScript.ClearLists();
        //         }
        //         GameManager.instance.SetIsEditing(true);
        //     }
        //     SceneManager.LoadScene("SampleCarCreation");
        // }
    }
    public static void BackToEditScene(){
        if (GameManager.instance)
        {
            //AudioManager.Instance.StopAll();
            GameManager.instance.GetVehicle.transform.position = new Vector3(0,0,0);
            Vehicle2 vehicleScript;
            if (GameManager.instance.GetVehicle.TryGetComponent<Vehicle2>(out vehicleScript)){
                vehicleScript.ClearLists();
                vehicleScript.ResetMaterial();
            }
            GameManager.instance.SetIsEditing(true);
        }
    }
    public static void GoToGameScene(){
        if (GameManager.instance)
        {
            //AudioManager.Instance.StopAll();
            GameManager.instance.SetIsEditing(false);
            GameManager.instance.SetCanCreate(false);
            GameManager.instance.SetCanDestroy(false);
            // GameManager.instance.GetVehicle.GetComponent<Vehicle2>().Config();
            Vehicle2 vehicleScript;
            if (GameManager.instance.GetVehicle.TryGetComponent<Vehicle2>(out vehicleScript)){
                vehicleScript.ResetMaterial();
            }
            GameManager.instance.GetVehicle.transform.position = new Vector3(1000,1000,1000);
        }
    }
}
