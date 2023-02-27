using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SaveData(UIManager scoreData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data playerData = new Data(scoreData);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data pData =formatter.Deserialize(stream) as Data;
            stream.Close();
            return pData;
        }
        else if (!File.Exists(path))
        {
            Debug.LogError("Save file was not found in " + path);
            return null;
        }
        return null;
    } 
}
