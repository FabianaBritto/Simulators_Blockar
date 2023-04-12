using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public class SaveVariables: MonoBehaviour
    {
        //Esse script contém as variaveis que irão ser salvas
        //Aqui que é para mudar o valor delas e chamar os metodos Save e Load
        
        public static SaveVariables Instance;
        private void Awake()
        {
            if(Instance) {Destroy(gameObject); return;}
        
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        #region Variaveis

        public int variavel1;
        public float variavel2;
        public float[] variavel3;//Para usar se precisar de vector3/transform
        public bool variavel4;

        #endregion

        public void Save()
        {
            SaveSystem.Save(this);
        }
        public void Load()
        {
            SaveSystem.Load();
        }
    }
}