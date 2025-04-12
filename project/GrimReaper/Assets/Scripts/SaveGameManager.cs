using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string level;
    public string position;
    public string life;
    public string inventoryBanana;
    public string inventoryWatermelon;
    public string inventoryCherry;
    public string enemiesLeft;
    public string hasKey;
}

[System.Serializable]
public class SaveGameManager
{
    private static SaveGameManager m_instance = null;
    private SaveGameManager() { }
    public static SaveGameManager Instance()
    {
        return m_instance ??= new SaveGameManager();
    }
    private string _filePath = Application.persistentDataPath + "/MySaveData.txt";
    public void SaveGame(int level, Transform playerTransform, int life, int banana, int watermelon, int cherry, int enemies, bool hasKey)
    {
        var binaryFormatter = new BinaryFormatter();
        var file = File.Create(_filePath);

        var data = new PlayerData
        {
            level = level.ToString(),
            position = JsonUtility.ToJson(playerTransform.position),
            life = life.ToString(),
            inventoryBanana = banana.ToString(),
            inventoryWatermelon = watermelon.ToString(),
            inventoryCherry = cherry.ToString(),
            enemiesLeft = enemies.ToString(),
            hasKey = hasKey.ToString()
        };
        binaryFormatter.Serialize(file, data);
        file.Close();
        Debug.Log("Game Data Save");
    }

    public PlayerData LoadGame()
    {
        if (!File.Exists(_filePath)) { return null; }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(_filePath, FileMode.Open);
        PlayerData data = formatter.Deserialize(file) as PlayerData;
        file.Close();
        return data;
    }

}