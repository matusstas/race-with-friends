using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceMenu : MonoBehaviour
{
    // The goal is choose specific level or draw custom one
    
    public Button drawRaceBtn;
    public Button[] levelBtns;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // add listeners to click events
        drawRaceBtn.onClick.AddListener(DrawRaceBtn);
        foreach (Button btn in levelBtns)
        {
                btn.onClick.AddListener(()=>LevelBtn(btn));
        }
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawRaceBtn()
    {
        // got to "Draw" scene
        PlayerPrefs.SetInt("level", 0);
        SceneManager.LoadScene("DrawRaceScene");
    }

    int ExtractLevelNumberFromButtonName(string levelButtonName)
    {   
        // Extract level number from button name
        // Level 1 -> 1
        int levelNumber = int.Parse(levelButtonName.Replace("Btn", "").Replace("Level", ""));
        return levelNumber;
    }

    public void LevelBtn(Button btn)
    {
        // Go to specific level 
        Debug.Log("Level button: " + btn.name);
        int levelNumber = ExtractLevelNumberFromButtonName(btn.name);
        PlayerPrefs.SetInt("level", levelNumber);
        SceneManager.LoadScene("NewRace");
    }
    
    public void BackBtnClick()
    {
        // go back to "Name Players" scene
        SceneManager.LoadScene("NamePlayersScene");
    }
}
