using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceMenu : MonoBehaviour
{
    public Button drawRaceBtn;
    public Button levelBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        drawRaceBtn.onClick.AddListener(DrawRaceBtn);
        levelBtn.onClick.AddListener(LevelBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // on autodromBtn click
    public void DrawRaceBtn()
    {
        // load race scene
        PlayerPrefs.SetInt("level", 0);
        SceneManager.LoadScene("DrawRaceScene");
    }

    int ExtractLevelNumberFromButtonName(string levelButtonName)
    {   
        int levelNumber = int.Parse(levelButtonName.Replace("Btn", "").Replace("Level", ""));
        return levelNumber;
    }

    public void LevelBtn()
    {
        Debug.Log("level button: " + levelBtn.name);
        int levelNumber = ExtractLevelNumberFromButtonName(levelBtn.name);
        PlayerPrefs.SetInt("level", levelNumber);
        // load race scene
        SceneManager.LoadScene("NewRace");
    }
}
