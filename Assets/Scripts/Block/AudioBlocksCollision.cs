using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioBlocksCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        int choiseSound = Random.Range(0, 2);
        if(choiseSound == 0)
            AudioManager.Instance.Play("Hit Blocks 1", false);
        else
            AudioManager.Instance.Play("Hit Blocks 2", false);
    }
}
