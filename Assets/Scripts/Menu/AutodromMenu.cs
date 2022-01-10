using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AutodromMenu : MonoBehaviour
{
    // The goal is to choose between "Team vs. Team" and "All vs. All"
    
    public Button allBtn;
    public Button teamBtn;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // add listeners to click events
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
        // Set mode to "All vs. All" and to "Name Players" scene
        PlayerPrefs.SetString("mode", "all");
        SceneManager.LoadScene("NamePlayersScene");
    }

    public void TeamBtnClick()
    {
        // Set mode to "Team vs. Team" and to "Name Players" scene
        PlayerPrefs.SetString("mode", "team");
        SceneManager.LoadScene("NamePlayersScene");
    }

    public void BackBtnClick()
    {
        // go back
        SceneManager.LoadScene("PlayScene");
    }

}
