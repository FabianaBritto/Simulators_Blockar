using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkyBoxNames
{
    public enum skyboxName
    {
        SkyBox0,
        SkyBox1,
        SkyBox2,
        SkyBox3,
        SkyBox4,
        SkyBox5,
        SkyBox6,
        SkyBox7,
        SkyBox8,
        SkyBox9,
        SkyBox10,
        SkyBox11,
        SkyBox12,
        SkyBox13,
        SkyBox14,
        SkyBox15,
        SkyBox16,
        SkyBox17,
        SkyBox18,
        SkyBox19,
    }
}

public class AmbienceSounds
{
    public enum ambienceSounds
    {
        AmbienceMorningFlorest,
        AmbienceNightFlorest,
        AmbienceMorningCity,
        AmbienceNightCity,
        MusicInitialScreen,
        MusicGarage1,
        MusicGarage2,
        InitialRandom
    }
}
public class SkyboxScene : MonoBehaviour
{
    public static SkyboxScene Instance;
    private void Awake()
    {
        if(Instance) {Destroy(gameObject); return;}
        
        Instance = this;
        //DontDestroyOnLoad(gameObject);

        RenderSettings.skybox = skyboxMaterial[(int)name];
    }
    

    [SerializeField] private Material[] skyboxMaterial;
    [SerializeField] private SkyBoxNames.skyboxName name;

    [SerializeField] private AmbienceSounds.ambienceSounds ambienceSound;
    private void Start()
    {
        if (ambienceSound == AmbienceSounds.ambienceSounds.InitialRandom)
        {
            int music = Random.Range(0, 2);
            if (music == 0)
                ambienceSound = AmbienceSounds.ambienceSounds.MusicGarage1;
            else
                ambienceSound = AmbienceSounds.ambienceSounds.MusicGarage2;
        }

        StartCoroutine(WaitStartAudioManager());
    }

    IEnumerator WaitStartAudioManager()
    {
        AudioManager.Instance.StopAll();
        yield return new WaitForSeconds(1.1f);
        AudioManager.Instance.Play(ambienceSound.ToString(), true);
    }
    public void SetSkyBox(SkyBoxNames.skyboxName nameOf)
    {
        RenderSettings.skybox = skyboxMaterial[(int)nameOf];
    }
}
