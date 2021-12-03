using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button autodromBtn;
    public Button raceBtn;
    public Button drawRaceBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        autodromBtn.onClick.AddListener(AutodromBtnClick);
        raceBtn.onClick.AddListener(RaceBtnClick);
        drawRaceBtn.onClick.AddListener(DrawRaceBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // on autodromBtn click
    public void AutodromBtnClick()
    {
        // load autodrom scene
        SceneManager.LoadScene("Autodrom");
    }

    public void RaceBtnClick()
    {
        // load Race scene
        SceneManager.LoadScene("Race");
    }

    public void DrawRaceBtnClick() {
        SceneManager.LoadScene("DrawRace");
    }




}
