using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearData : MonoBehaviour
{
 public void Clear()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("SaveData has all been cleared");
    }
}
