using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Save;
using UnityEngine;

public class SaveSystem
{
    //Aqui salva e carrega as variaveis
    public static void Save(SaveVariables saveVariables)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveGame.features";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(saveVariables);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/saveGame.features";
        if (File.Exists(path))
        {
            Debug.Log("Path " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();
            return data;
        }
        
        Debug.LogError("Save do Game não encontrado em " + path);
        return null;
    }
}
