using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TweenToStart : MonoBehaviour
{
    public static TweenToStart Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public enum typeOfTween
    {
        random,
        objectsScaleBlocksFall,
    }
    
    [SerializeField] private TweenToStart.typeOfTween TypeOfTween;
    [SerializeField] private List<ModelsTweenToStart> modelsTweenToStarts;
    private int randomStart;

    private void Start()
    {
       StartLevel();
    }

    public void StartLevel()
    {
        if(TypeOfTween == typeOfTween.random)
            randomStart = Random.Range(0, 3);
        else
            randomStart = 2;

        foreach (var models in modelsTweenToStarts)
            models.DoTween(randomStart);
    }
    private void Update()
    {
        if(!Input.GetKeyDown(KeyCode.R)) return;
        if(TypeOfTween == typeOfTween.random)
            randomStart = Random.Range(0, 3);
        else
            randomStart = 2;

        foreach (var models in modelsTweenToStarts)
            models.DoTween(randomStart);
    }
}