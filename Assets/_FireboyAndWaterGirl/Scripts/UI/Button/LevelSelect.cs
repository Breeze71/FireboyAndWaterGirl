using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour, IPointerClickHandler
{
    #region test
    [HideInInspector]
    public UnityEvent rightClick;
    #endregion
    public GameObject[] Highlights;//Highlight Image
    public Image ButtonImage;
    public GameObject Newtext;//New
    public GameObject TipText;
    private string Father;//this level's previous level
    private void Awake()
    {
        Father = ReadLevelconfig.Instance.Data.Levels.Where((t) => t.Self == gameObject.name).ToList().First().Father;
    }
    private void Start()
    {
        #region test
        if (Application.isEditor)
        {
            rightClick.AddListener(new UnityAction(Test));
        }
        #endregion

        ButtonImage = GetComponent<Image>();
    }
    private void Update()
    {
        UpdateLevelImage();//TODO move later
    }
    /// <summary>
    /// change Button'image color if success
    /// </summary>
    void ChangeClor()
    {
        ButtonImage.color = Color.green;
    }
    /// <summary>
    /// update UI image 
    /// </summary>
    void UpdateLevelImage()
    {
        if (PlayerPrefs.GetString(Father, "unlocked") != "Successed")
        {
            foreach (GameObject t in Highlights)
            {
                t.SetActive(false);
            }
            ButtonImage.color = Color.gray;
            Newtext.SetActive(false);
        }
        else if (PlayerPrefs.GetString(Father)=="Successed" && PlayerPrefs.GetString(gameObject.name,"-1") == "-1")
        {
            Newtext.SetActive(true);
        }
        else if (PlayerPrefs.GetString(Father) == "Successed" && PlayerPrefs.GetString(gameObject.name, "-1") == "Tried")
        {
            Newtext.SetActive(false);
        }
        else if (PlayerPrefs.GetString(gameObject.name) == "Successed")
        {
            Newtext.SetActive(false);
            foreach (GameObject t in Highlights)
            {
                t.SetActive(true);
            }
            ButtonImage.color = Color.green;
        }
    }
    /// <summary>
    /// try to play this level 
    /// </summary>
    public void PressSelection()
    {
        if (PlayerPrefs.GetString(Father, "unlocked") != "Successed")
        {
            SceneManager.LoadScene(gameObject.name);
        }
        //when player try to open clocked level,display Tip
        else if (PlayerPrefs.GetString(gameObject.name,"-1") == "Successed")
        {
            TipText.SetActive(true);
            StartCoroutine(CloseTip());
        }
    }

    //wait for 1 second then closeing Tip
    private IEnumerator CloseTip()
    {
        yield return new WaitForSeconds(1);
        TipText.SetActive(false);
    }
    #region test
    public void Test()
    {
        PlayerPrefs.SetString(gameObject.name, "Successed");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();
        }
    }
    #endregion
}
