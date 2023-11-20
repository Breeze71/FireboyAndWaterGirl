using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public GameObject ContinueButton;
    private void Awake()
    {
        #region register in GameEventManager
        GameEventManager.Instance.playerEvent.OnPlayerDead += SetActice;
        GameEventManager.Instance.playerEvent.OnPlayerDead += Dead;
        GameEventManager.Instance.playerEvent.OnPlayerWin += SetActice;
        GameEventManager.Instance.playerEvent.OnPlayerWin += Successed;
        #endregion

        ContinueButton.SetActive(false);
    }
    public void SetActice()
    {
        ContinueButton.SetActive(true);
    }
    public void ContinueTo0()
    {
        Debug.Log("---");
        SceneManager.LoadScene("Lv0");
    }
    public void Dead()
    {
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "Tried");
        PlayerPrefs.Save();
    }
    public void Successed()
    {
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "Successed");
        PlayerPrefs.Save();
    }

}
