using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AutodromMenu : MonoBehaviour
{
    public Button allBtn;
    public Button teamBtn;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        allBtn.onClick.AddListener(AllBtnClick);
        teamBtn.onClick.AddListener(TeamBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // on autodromBtn click
    public void AllBtnClick()
    {
        // load race scene
        PlayerPrefs.SetString("mode", "all");
        SceneManager.LoadScene("NamePlayersScene");
    }

    public void TeamBtnClick()
    {
        // load autodrom scene
         PlayerPrefs.SetString("mode", "team");
        SceneManager.LoadScene("NamePlayersScene");
    }

    public void BackBtnClick()
    {
        // load play scene
        SceneManager.LoadScene("PlayScene");
    }

}
