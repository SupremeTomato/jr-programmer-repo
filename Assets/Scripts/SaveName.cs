using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveName : MonoBehaviour
{
    // Start is called before the first frame update
    public static SaveName Instance;
    public string playerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerName();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
    }

    public void SavePlayerName()
    {

        SaveData data = new SaveData();
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }
}
