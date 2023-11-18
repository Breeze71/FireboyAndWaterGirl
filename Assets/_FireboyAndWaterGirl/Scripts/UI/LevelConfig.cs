using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#region Level Data
[System.Serializable]
public class Level
{
    public string Self;
    public string Father;
    public Level(string Self, string Father)
    {
        this.Self = Self;
        this.Father = Father;
    }
    //public string[] Children;
}
[System.Serializable]
public class Data
{
    public List<Level> Levels;
}
#endregion
public class LevelConfig : MonoBehaviour
{
    void Start()
    {
        WriteData(Readtxt());
    }
    /// <summary>
    /// read then convert raw-txt's format
    /// </summary>
    public List<string[]> Readtxt()
    {

        string[] RawtextTxt = File.ReadAllLines(Application.streamingAssetsPath + "/LevelConfig.txt");
        List<string[]> textTxt = new List<string[]>();
        foreach (string rawtext in RawtextTxt)
        {
            textTxt.Add(rawtext.Split(","));
        }
        return textTxt;
    }
    /// <summary>
    /// save txt as json
    /// </summary>
    public void WriteData(List<string[]> textTxt)
    {
        Data m_Data = new Data();
        m_Data.Levels = new List<Level>();
        foreach (var item in textTxt)
        {
            m_Data.Levels.Add(new(item[0], item[1]));
        }
        string js = JsonUtility.ToJson(m_Data);
        string fielUrl = Application.streamingAssetsPath + "/LevelInfo.json";
        using (StreamWriter sw = new StreamWriter(fielUrl))
        {
            sw.WriteLine(js);
            sw.Close();
            sw.Dispose();
        }
        Debug.Log("json has saved");
    }
}
