using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    public Button raceBtn;
    public Button autodromBtn;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        raceBtn.onClick.AddListener(RaceBtnClick);
        autodromBtn.onClick.AddListener(AutodromBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // on autodromBtn click
    public void RaceBtnClick()
    {
        // load race scene
        SceneManager.LoadScene("ChooseNumberOfPlayersScene");
        PlayerPrefs.SetString("gameMode","race");
    }

    public void AutodromBtnClick()
    {
        // load autodrom scene
        SceneManager.LoadScene("AutodromScene");
        PlayerPrefs.SetString("gameMode","autodrom");
    }

    public void BackBtnClick()
    {
        // load main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
