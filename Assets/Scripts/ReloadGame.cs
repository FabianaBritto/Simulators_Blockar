using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;

public class ReloadGame : MonoBehaviour
{
    private bool trigger = false;
    public Target target;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Block"))return;
            
        if(trigger) return;
        trigger = true;
        target.ExplosionCall(false, 0.5f);
    }
}
