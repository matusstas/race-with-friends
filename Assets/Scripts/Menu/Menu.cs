using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button playBtn;
    public Button controlsBtn;
    public Button exitGameBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
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
        // load play scene
        SceneManager.LoadScene("PlayScene");
    }

    public void ControlsBtnClick()
    {
        // load controls scene
        SceneManager.LoadScene("ControlsScene");
    }

    public void ExitGameBtnClick()
    {
        Debug.Log("Exit game button clicked");
        // exit game
        Application.Quit();
    }

}
