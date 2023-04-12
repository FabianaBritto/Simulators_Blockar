using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class InitialMap : MonoBehaviour
{
    [SerializeField] GameObject[] maps;
    int randomMap;

    void Start()    
    {
        randomMap = Random.Range(0, maps.Length);

        foreach(GameObject map in maps)
            map.SetActive(false);

        maps[randomMap].SetActive(true);

        switch (randomMap)
        {
            case 0:
                SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox0);
                break;
            case 1:
                SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox13);
                break;
            case 2:
                SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox2);
                break;
            case 3:
                SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox19);
                break;
            case 4:
                SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox5);
                break;
            case 5:
                SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox6);
                break;
        }
    }
}
