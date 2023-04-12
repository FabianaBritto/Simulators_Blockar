using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    [SerializeField] private GameObject tutorial;

    public void EnableTutorial(bool state)
    {
        tutorial.SetActive(state);
    }

    private void OnDisable()
    {
        tutorial.SetActive(false);
    }
}
