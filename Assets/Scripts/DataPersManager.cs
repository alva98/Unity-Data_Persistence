using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPersManager : MonoBehaviour
{
    public static DataPersManager instance;

    public string playerStr;  // variable, name of the player as datum persistence
    public int bestScore;  // current best score of the player as datum persistence

    private void Awake()
    {
        // verify if exists an instance
        if(instance != null)
        {
            Destroy(gameObject);  // destroy early instance if it exists
            return;
        }
        DontDestroyOnLoad(gameObject);  // doesn't destroy the gameobject
        instance = this;  // Creates the instance

        LoadPlayer();  // load name of player at first
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerData;
        public int bestScoreData;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.playerData = playerStr;
        data.bestScoreData = bestScore;

        // path and name of the saved file for data-persistence
        string path = Application.persistentDataPath + "/dataplayer.json";

        // convert class SaveData format to string of player
        string jsonFile = JsonUtility.ToJson(data);
        // write the file
        File.WriteAllText(path, jsonFile);
    }

    public void LoadPlayer()
    {
        // path and name of the saved file for data-persistence
        string path = Application.persistentDataPath + "/dataplayer.json";

        // if the file exists, it reads
        if (File.Exists(path))
        {
            string jsonFile = File.ReadAllText(path);  // reads from file to a string
            // convert string to class SaveData format
            SaveData data = JsonUtility.FromJson<SaveData>(jsonFile);
            // assign value of player (class SaveData) to player (class DataPersManager)
            playerStr = data.playerData;
            bestScore = data.bestScoreData;
        }
        else
            Debug.Log("No hay datos guardados");
    }
}
