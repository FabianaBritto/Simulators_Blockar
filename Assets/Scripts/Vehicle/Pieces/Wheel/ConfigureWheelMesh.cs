using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Block;

public class ConfigureWheelMesh : MonoBehaviour
{
    [SerializeField] private PieceData pieceData;
    [SerializeField] private GameObject wheelMesh;
    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private BlockBehavior blockBehavior;
    public int currentDirection = -1;
    private void Start()
    {
        if (this.gameObject.transform.parent != null)
        {
            if(this.gameObject.transform.parent.parent.name != "Vehicle(Clone)"){
                // AddWheelCollider();
                // blockBehavior.wheelCollider = wheelCollider;
                ConfigureMesh();
            }
        }
    }
    private void AddWheelCollider(){
        wheelCollider = this.transform.gameObject.AddComponent<WheelCollider>();
        wheelCollider.mass = 20.0f;
        wheelCollider.radius = 0.6f;
        wheelCollider.wheelDampingRate = 0.25f;
        wheelCollider.suspensionDistance = 0.4f;
        wheelCollider.forceAppPointDistance = 0.0f;
        JointSpring suspensionSpring = new() /* = wheelCollider.suspensionSpring */;
        suspensionSpring.spring = 35000.0f;
        suspensionSpring.damper = 4500.0f;
        suspensionSpring.targetPosition = 0.5f;
        wheelCollider.suspensionSpring = suspensionSpring;
        WheelFrictionCurve fowardFriction = new()/* wheelCollider.forwardFriction */;
        fowardFriction.extremumSlip = 0.4f;
        fowardFriction.extremumValue = 1.0f;
        fowardFriction.asymptoteSlip = 0.8f;
        fowardFriction.asymptoteValue = 0.5f;
        fowardFriction.stiffness = 1.0f;
        wheelCollider.forwardFriction = fowardFriction;
        WheelFrictionCurve sidewaysFriction = new()/* = wheelCollider.sidewaysFriction */;
        sidewaysFriction.extremumSlip = 0.2f;
        sidewaysFriction.extremumValue = 1.0f;
        sidewaysFriction.asymptoteSlip = 0.5f;
        sidewaysFriction.asymptoteValue = 0.75f;
        sidewaysFriction.stiffness = 1.0f;
        wheelCollider.sidewaysFriction = sidewaysFriction;
    }
    private void ConfigureMesh(){
        Quaternion _rotation = new Quaternion();
        switch (currentDirection)
        {
            case 0://forward
                // _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                // break;
            case 1://back
                // _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                // break;
            case 2://left
                // _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                // break;
            case 3://right
                // _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                // break;
            case 4://up
                // _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
                // break;
            case 5://down
                // _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            default:
                break;
        }
        wheelMesh.transform.GetChild(1).GetChild(1).transform.rotation = _rotation;
    }
}
