using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // The goal is to start the game or to read information about controls
    public Button playBtn;
    public Button controlsBtn;
    public Button exitGameBtn;

    // Start is called before the first frame update
    void Start()
    {
        // add listeners to click events
        playBtn.onClick.AddListener(PlayBtnClick);
        controlsBtn.onClick.AddListener(ControlsBtnClick);
        exitGameBtn.onClick.AddListener(ExitGameBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBtnClick()
    {
        // go to "Choose number of players" scene
        SceneManager.LoadScene("ChooseNumberOfPlayersScene");
    }

    public void ControlsBtnClick()
    {
        // go to "Controls" scene
        SceneManager.LoadScene("ControlsScene");
    }

    public void ExitGameBtnClick()
    {
        // Exit game
        Debug.Log("Exit game button clicked");
        Application.Quit();
    }

}
