using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMesh : MonoBehaviour
{
    // [SerializeField] private WheelCollider wheelCollider;
    // void FixedUpdate()
    // {
    //     if(wheelCollider != null){
    //         Vector3 _position;
    //         Quaternion _rotation;
    //         wheelCollider.GetWorldPose(out _position, out _rotation);
    //         this.transform.position = _position;
    //         this.transform.rotation = _rotation;
    //     }
    // }
    // public void SetWheelCollider(WheelCollider _wheelCollider){
    //     wheelCollider = _wheelCollider;
    // }
    private void OnDestroy() {
        // Destroy(transform.parent.gameObject);
    }
}
