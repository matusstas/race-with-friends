using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    public Button raceBtn;
    public Button autodromBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        raceBtn.onClick.AddListener(RaceBtnClick);
        autodromBtn.onClick.AddListener(AutodromBtnClick);
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
    }

    public void AutodromBtnClick()
    {
        // load autodrom scene
        SceneManager.LoadScene("AutodromScene");
    }

}
