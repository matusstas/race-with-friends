using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlsMenu : MonoBehaviour
{
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        backBtn.onClick.AddListener(BackBtnClick);
    }

    public void BackBtnClick()
    {
        int isHPressed = PlayerPrefs.GetInt("isHPressed");
        if (isHPressed == 1) {
            PlayerPrefs.SetInt("isHPressed", 0);

            string gameMode = PlayerPrefs.GetString("gameMode");
            if (gameMode == "race")
            {
                // load race scene
                SceneManager.LoadScene("NewRace");
            } else
            {
                // load autodrom scene
                SceneManager.LoadScene("AutodromScene");
            }
        } else {
            // load main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}
