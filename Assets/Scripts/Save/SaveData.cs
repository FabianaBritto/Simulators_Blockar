using System.Collections;
using System.Collections.Generic;
using Save;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //Esse script contem as variais que serão salvas e carregadas
    //varievel1 = variavel1 do jogo
    
    #region Variaveis

    public int variavel1;
    public float variavel2;
    public float[] variavel3;//Para usar se precisar de vector3/transform
    public bool variavel4;

    #endregion
    public SaveData(SaveVariables saveVariables)
    {
        variavel1 = saveVariables.variavel1;
        variavel2 = saveVariables.variavel2;
        variavel3 = saveVariables.variavel3;
        variavel4 = saveVariables.variavel4;
    }
}
