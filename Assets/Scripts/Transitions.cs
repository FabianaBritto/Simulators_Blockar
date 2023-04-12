using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Transitions : MonoBehaviour
{
    public static Transitions Instance;

    [SerializeField] Image quad;
    [SerializeField] private Color32[] colors;

    private List<Image> quadsInstances = new List<Image>();
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        //StartCoroutine(TransitionsInVertical_1());
    }

    public void ChooseeTransition(int tran)
    {
        switch (tran)
        {
            case 0:
                StartCoroutine(TransitionsInVertical_1());
                break;
            case 1:
                StartCoroutine(TransitionsInVertical_2());
                break; 
            case 2:
                StartCoroutine(TransitionsInHorizontal_1());
                break; 
            case 3:
                StartCoroutine(TransitionsInHorizontal_2());
                break;
        }
    }

    public void DestroyTransitions()
    {
        StartCoroutine(GetOutTransition());
    }
    IEnumerator GetOutTransition()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < quadsInstances.Count; i++)
        {
            Destroy(quadsInstances[i]);
            yield return new WaitForSeconds(0.0001f);
        }

        TweenToStart.Instance.StartLevel();
    }    
    IEnumerator TransitionsInVertical_1()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 pos;
        pos = new Vector3(-64.0f, 1119.0f,0);
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                Image instance = Instantiate(quad, pos, Quaternion.identity, transform);
                instance.color = colors[Random.Range(0, colors.Length)];
                pos = new Vector3(pos.x + 128, pos.y, pos.z);
                
                quadsInstances.Add(instance);
                yield return new WaitForSeconds(0.0001f);
            }
            pos = new Vector3(-64.0f,  pos.y-128,0);
        }
    }
    IEnumerator TransitionsInVertical_2()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 pos;
        pos = new Vector3(-64.0f, 1119.0f,0);
        for (int i = 0; i < 11; i++)
        {
           
            for (int j = 0; j < 18; j++)
            {
                Image instance = Instantiate(quad, pos, Quaternion.identity, transform);
                instance.color = colors[Random.Range(0, colors.Length)];
                pos = new Vector3(pos.x + 128, pos.y, pos.z);
                
                quadsInstances.Add(instance);
            }
            yield return new WaitForSeconds(0.0001f);
            pos = new Vector3(-64.0f,  pos.y-128,0);
        }
    }

    IEnumerator TransitionsInHorizontal_1()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 pos;
        pos = new Vector3(-64.0f, 1119.0f,0);
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Image instance = Instantiate(quad, pos, Quaternion.identity, transform);
                instance.color = colors[Random.Range(0, colors.Length)];
                pos = new Vector3(pos.x, pos.y- 128, pos.z);
                quadsInstances.Add(instance);
                yield return new WaitForSeconds(0.0001f);
            }
            pos = new Vector3(pos.x +128, 1119.0f,0);
        }  
    }
    IEnumerator TransitionsInHorizontal_2()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 pos;
        pos = new Vector3(-64.0f, 1119.0f,0);
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Image instance = Instantiate(quad, pos, Quaternion.identity, transform);
                instance.color = colors[Random.Range(0, colors.Length)];
                pos = new Vector3(pos.x , pos.y- 128, pos.z);
                quadsInstances.Add(instance);
            }
            yield return new WaitForSeconds(0.0001f);
            pos = new Vector3(pos.x +128, 1119.0f,0);
        } 
    }
}
