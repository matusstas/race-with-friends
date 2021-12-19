using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceMenu : MonoBehaviour
{
    public Button drawRaceBtn;
    public Button[] levelBtns;

    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
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

    public void LevelBtn(Button btn)
    {

        Debug.Log("level button: " + btn.name);
        int levelNumber = ExtractLevelNumberFromButtonName(btn.name);
        PlayerPrefs.SetInt("level", levelNumber);
        // load race scene
        SceneManager.LoadScene("NewRace");
    }
    
    public void BackBtnClick()
    {
        // load main menu scene
        // SceneManager.LoadScene("ChooseNumberOfPlayersScene");
        SceneManager.LoadScene("NamePlayersScene");
    }
}
