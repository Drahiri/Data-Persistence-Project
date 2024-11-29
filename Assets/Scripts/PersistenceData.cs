using System;
using System.IO;
using UnityEngine;

public class PersistenceData : MonoBehaviour
{
    public static PersistenceData instance;

    public string currentPlayerName;
    public string highScorePlayerName;
    public int highScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }

    [Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public string highscorePlayerName;
        public int highScore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.highscorePlayerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentPlayerName = data.currentPlayerName;
            highScorePlayerName = data.highscorePlayerName;
            highScore = data.highScore;
        }
    }
}
