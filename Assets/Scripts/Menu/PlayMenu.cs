using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    // The goal is to choose between race and autodrom mode
    
    public Button raceBtn;
    public Button autodromBtn;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // add listeners to click events
        raceBtn.onClick.AddListener(RaceBtnClick);
        autodromBtn.onClick.AddListener(AutodromBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaceBtnClick()
    {
        // go to "Name PLayers" scene, set mode to "All vs. All" and gamemode to race
        SceneManager.LoadScene("NamePlayersScene"); 
        PlayerPrefs.SetString("mode", "all");
        PlayerPrefs.SetString("gameMode","race");
    }

    public void AutodromBtnClick()
    {
        // go to autodrom scene and set gamemode to autodrom
        SceneManager.LoadScene("AutodromMenuScene");
        PlayerPrefs.SetString("gameMode","autodrom");
    }

    public void BackBtnClick()
    {
        // go back
        SceneManager.LoadScene("ChooseNumberOfPlayersScene");
    }
}
