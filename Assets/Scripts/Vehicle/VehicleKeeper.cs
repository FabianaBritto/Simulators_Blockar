using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleKeeper : MonoBehaviour
{
    public static VehicleKeeper instance;
    private Rigidbody myRigidBody;

    private void Awake()
    {
        if (this.gameObject.name != "Vehicle(Clone)")
        {
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
        TryGetComponent<Rigidbody>(out myRigidBody);
    }
    private void Update()
    {
        if (GameManager.instance.GetIsEditing && this.gameObject.name == "Vehicle")
        {
            InEditMode();
        }
        // else
        // {
        //     OutOfEditMode();
        // }
        if (this.gameObject.name == "Vehicle(Clone)")
        {
            OutOfEditMode();
        }
    }
    /// <summary>
    ///     Private function to lock blocks when is in EditMode
    /// </summary>
    private void InEditMode()
    {
        myRigidBody.useGravity = false;
        myRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        myRigidBody.Sleep();
        myRigidBody.isKinematic = true;
    }
    /// <summary>
    ///     Private function to unlock blocks when is out of EditMode
    /// </summary>
    private void OutOfEditMode()
    {
        myRigidBody.useGravity = true;
        myRigidBody.constraints = RigidbodyConstraints.None;
        myRigidBody.isKinematic = false;
    }
}
