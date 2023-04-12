using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Audio;
using UnityEngine;
using Block;
using UnityEngine.SceneManagement;

public class Vehicle2 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float torqueTotal;
    [SerializeField] private float torqueWheel;
    [SerializeField] private List<BlockScrObj> blocks = new();
    [SerializeField] private List<EngineScrObj> engines = new();
    [SerializeField] private List<WheelCollider> wheels = new();
    [SerializeField] private List<GameObject> pieces = new();
    [SerializeField] public List<GameObject> Pieces {get{return pieces;} set{pieces = value;}}

    private void Start() {
        if (this.gameObject.name != "Vehicle")
        {
            Config();
        }
        if(SceneManager.GetActiveScene().name != "SampleCarCreation")
            AudioManager.Instance.Play("Motor", true);
        StartCoroutine(CheckSceneAudioAgain());
    }

    IEnumerator CheckSceneAudioAgain()
    {
        yield return new WaitForSeconds(1.1f);
        if(SceneManager.GetActiveScene().name != "SampleCarCreation")
            AudioManager.Instance.Play("Motor", true);
        
    }
    public void Config()
    {
        GetAllBlockBehavior();
        ConfigRigidbody();
    }

    private void FixedUpdate()
    {
        foreach (var wheel in wheels)
        {
            wheel.brakeTorque = 0f;
            wheel.motorTorque = torqueWheel;
        }
    }


    private void ConfigRigidbody()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0f;

        CalcMass();
        CalcTorque();
    }
    public void ClearLists(){
        blocks = new();
        engines = new();
        wheels = new();
    }
    public void ClearVehicle(){
        pieces = new();
        foreach (var item in transform.GetComponentsInChildren<BlockBehavior>())
        {
            if (item.gameObject.name != "BlockMain")
            {
                Destroy(item.gameObject);
            }
        }
    }
    public void ResetMaterial()
    {
        PieceMaterial[] pieceMaterials = GetComponentsInChildren<PieceMaterial>();
        foreach (var block in pieceMaterials)
            block.SendMessage("ResetMaterial");
    }

    private void ConfigWheelCollider()
    {
        foreach (var wheel in wheels)
        {
            wheel.mass = 20;
            wheel.brakeTorque = torqueTotal * 3;
            wheel.motorTorque = 0f;

            float suspension = rb.mass * 6;
            wheel.suspensionSpring = new JointSpring
            {
                spring = suspension * 10,
                damper = suspension
            };
        }
    }

    private void GetAllBlockBehavior()
    {
        // foreach (Transform child in transform)
        // {
        //     BlockBehavior block = child.GetComponent<BlockBehavior>();
        //     if (!block) continue;

        //     switch (block.type)
        //     {
        //         case BlockBehavior.Types.Engine:
        //             engines.Add((EngineScrObj) block.settings);
        //             break;
        //         case BlockBehavior.Types.Standard:
        //             blocks.Add(block.settings);
        //             break;
        //         case BlockBehavior.Types.Wheel:
        //             wheels.Add(block.wheelCollider);
        //             break;
        //     }
        // }

        //mudei para os blocos poderem continuar organizados no editor

        BlockBehavior[] blockBehaviors = GetComponentsInChildren<BlockBehavior>();
        foreach (var block in blockBehaviors)
        {
            switch (block.type)
            {
                case BlockBehavior.Types.Engine:
                    engines.Add((EngineScrObj)block.settings);
                    break;
                case BlockBehavior.Types.Standard:
                    blocks.Add(block.settings);
                    break;
                case BlockBehavior.Types.Wheel:
                    wheels.Add(block.wheelCollider);
                    break;
            }
        }
    }

    private void CalcMass()
    {
        int mass = 0;
        mass += blocks.Sum(block => block.mass);
        mass += engines.Sum(engine => engine.mass);
        rb.mass = mass;
    }

    private void CalcTorque()
    {
        torqueTotal = engines.Sum(engine => engine.torque);
        torqueWheel = torqueTotal;
        ConfigWheelCollider();
    }
}
