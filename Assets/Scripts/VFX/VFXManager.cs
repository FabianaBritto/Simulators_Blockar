using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct VFXs
{
    public string name;
    public GameObject vfxGameObj;
    public ParticleSystem vfxParticleSys;
}
public class VFXManager : MonoBehaviour
{
    //public static VFXManager Instance;
    public bool enableVFX;
    private void Awake()
    {
        /*if(Instance) {Destroy(gameObject); return;}
        
        Instance = this;
        //DontDestroyOnLoad(gameObject);*/
       
    }

    private void Start()
    {
        if (enableVFX)
            StartCoroutine(EnableTheVFX());
    }

    IEnumerator EnableTheVFX()
    {
        yield return new WaitForSeconds(1.5f);
        foreach (var var in vfXsList)
        {
            var.vfxGameObj.SetActive(true);
        }
    }
    [SerializeField] private VFXs[] vfXsList;
    
    
    //Metodos para ativar/desativar
    //Metodos para mudar propriedades e tempo seila..

    public void EnableVFX(string vfxName)
    {
        VFXs vfx = Array.Find(vfXsList, vFXs =>  vFXs.name == vfxName);

        foreach (var var in vfXsList)
        {
            if(var.name == vfxName)
                vfx.vfxGameObj.SetActive(true);
        }
        //vfx.vfxParticleSys.seila;
    }
    public void DisableVFX(string vfxName)
    {
        VFXs vfx = Array.Find(vfXsList, vFXs =>  vFXs.name == vfxName);

        foreach (var var in vfXsList)
        {
            if(var.name == vfxName)
                vfx.vfxGameObj.SetActive(false);
        }
        //vfx.vfxParticleSys.seila;
    }

    public void ChangePos(Vector3 pos, string vfxName)
    {
        VFXs vfx = Array.Find(vfXsList, vFXs =>  vFXs.name == vfxName);

        foreach (var var in vfXsList)
        {
            if (var.name == vfxName)
                vfx.vfxGameObj.transform.position = pos;
        }
    }
}
