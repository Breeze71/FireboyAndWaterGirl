using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadLevelconfig : MonoBehaviour
{
    public static ReadLevelconfig Instance { get; set; }
    private Data data;
    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            string jsonData = ReadData();
            data = JsonUtility.FromJson<Data>(jsonData);
        }
    }
    /// <summary>
    /// Read json
    /// </summary>
    public string ReadData()
    {
        string readData;
        string fielUrl = Application.streamingAssetsPath + "/LevelInfo.json";
        using (StreamReader sr = new StreamReader(fielUrl))
        {
            readData = sr.ReadToEnd();
            sr.Close();
        }
        return readData;
    }
    #region interface to LevelSelect
    public Data Data { get { return data; } }
    #endregion
}
