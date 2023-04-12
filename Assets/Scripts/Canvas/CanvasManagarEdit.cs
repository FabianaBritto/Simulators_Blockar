using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AutoPilot;

public class CanvasManagarEdit : MonoBehaviour
{
    [Header("Defaults")]
    [SerializeField] private Button standardButton;
    [SerializeField] private Button engineButton;
    [SerializeField] private Button wheelButton;
    [SerializeField] private Button removeButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button clearVehicleButton;
    [Space(10)]

    [Header("Standard")]
    [SerializeField] private Button standardLevel1Button;
    [SerializeField] private Button standardLevel2Button;
    [SerializeField] private Button standardLevel3Button;
    [Space(10)]
    
    [Header("Engine")]
    [SerializeField] private Button engineLevel1Button;
    [SerializeField] private Button engineLevel2Button;
    [SerializeField] private Button engineLevel3Button;
    [Space(10)]
    
    [Header("Wheel")]
    [SerializeField] private Button wheelSimpleButton;
    [SerializeField] private Button wheelSimpleBackButton;
    [SerializeField] private Button wheelSimpleFrontButton;
    [SerializeField] private Button wheelTopButton;
    [SerializeField] private Button wheelTopBackButton;
    [SerializeField] private Button wheelTopFrontButton;
    // [Space(10)]
    
    // [Header("Empty's")]
    // [SerializeField] private GameObject standard;
    // [SerializeField] private GameObject engine;
    // [SerializeField] private GameObject wheel;


    private void Update() {
        if (Input.GetMouseButtonDown(1))//Cancels create and destroy
        {
            GameManager.instance.SetCanCreate(false);
            GameManager.instance.SetCanDestroy(false);
            // engine.SetActive(false);
            // wheel.SetActive(false);
            // standard.SetActive(false);
        }
    }

    void Start()
    {
        #region  Standard
        standardButton.onClick.AddListener(ClickStandardButton);
        standardLevel1Button.onClick.AddListener(ClickStandardLevel1Button);
        standardLevel2Button.onClick.AddListener(ClickStandardLevel2Button);
        standardLevel3Button.onClick.AddListener(ClickStandardLevel3Button);
        #endregion

        #region Engine
        engineButton.onClick.AddListener(ClickEngineButton);
        engineLevel1Button.onClick.AddListener(ClickEngineLevel1Button);
        engineLevel2Button.onClick.AddListener(ClickEngineLevel2Button);
        engineLevel3Button.onClick.AddListener(ClickEngineLevel3Button);
        #endregion

        #region Wheel
        wheelButton.onClick.AddListener(ClickWheelButton);
        wheelSimpleButton.onClick.AddListener(ClickWheelSimpleButton);
        wheelSimpleBackButton.onClick.AddListener(ClickWheelSimpleBackButton);
        wheelSimpleFrontButton.onClick.AddListener(ClickWheelSimpleFrontButton);
        wheelTopButton.onClick.AddListener(ClickWheelTopButton);
        wheelTopBackButton.onClick.AddListener(ClickWheelTopBackButton);
        wheelTopFrontButton.onClick.AddListener(ClickWheelTopFrontButton);
        #endregion

        removeButton.onClick.AddListener(ClickRemoveButton);
        clearVehicleButton.onClick.AddListener(ClickClearVehicleButton);
        playButton.onClick.AddListener(ClickPlayButton);
    }
    public static void ClickStandardButton(){
        // engine.SetActive(false);
        // wheel.SetActive(false);
        // standard.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickStandardLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickStandardLevel2Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel2");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickStandardLevel3Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel3");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickEngineButton(){
        // standard.SetActive(false);
        // wheel.SetActive(false);
        // engine.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickEngineLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickEngineLevel2Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel2");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickEngineLevel3Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel3");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    public static void ClickWheelButton(){
        // standard.SetActive(false);
        // engine.SetActive(false);
        // wheel.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimple");
        GameManager.instance.SetPlaceHolder("WheelSimple");
    }
    public static void ClickWheelSimpleButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimple");
        GameManager.instance.SetPlaceHolder("WheelSimple");
    }
    public static void ClickWheelSimpleBackButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimpleBack");
        GameManager.instance.SetPlaceHolder("WheelSimpleBack");
    }
    public static void ClickWheelSimpleFrontButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimpleFront");
        GameManager.instance.SetPlaceHolder("WheelSimpleFront");
    }
    public static void ClickWheelTopButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelTop");
        GameManager.instance.SetPlaceHolder("WheelTop");
    }
    public static void ClickWheelTopBackButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelTopBack");
        GameManager.instance.SetPlaceHolder("WheelTopBack");
    }
    public static void ClickWheelTopFrontButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelTopFront");
        GameManager.instance.SetPlaceHolder("WheelTopFront");
    }
    public static void ClickRemoveButton(){
        GameManager.instance.SetCanCreate(false);
        GameManager.instance.SetCanDestroy(true);
    }
    public static void ClickClearVehicleButton(){
        GameManager.instance.GetVehicle.GetComponent<Vehicle2>().ClearVehicle();
    }

    public static void ClickPlayButton(){
        //AudioManager.Instance.StopAll();
        SceneManager.LoadScene(EditModeLevelController.instance.currentScene);
        EditModeLevelController.GoToGameScene();
        // GameManager.instance.SetIsEditing(false);
        // GameManager.instance.SetCanCreate(false);
        // GameManager.instance.SetCanDestroy(false);
        // GameManager.instance.GetVehicle.GetComponent<Vehicle2>().Config();
        // GameManager.instance.GetVehicle.transform.position = new Vector3(1000,1000,1000);
        // FindObjectOfType<VehicleChanger>().VehicleObject = GameManager.instance.GetVehicle;
    }
}
