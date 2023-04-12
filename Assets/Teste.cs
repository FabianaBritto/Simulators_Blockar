using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teste : MonoBehaviour
{
    public static Teste instance;
    void Awake()
    {
        if (instance) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(15))
        {
            Invoke("Muda()", 1.0f);
            Debug.Log("aloU");
        }
        else
        {
            this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            Debug.Log("Uola");
        }

    }
    void Muda(){
        this.transform.localPosition = new Vector3(0.0f, 1.0f, -20.0f);
        GameManager.instance.SetCanCreate(false);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetIsEditing(false);
    }
}
