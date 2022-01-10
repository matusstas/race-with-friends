using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultsMenu : MonoBehaviour
{
    public Button againBtn;
    public Button menuBtn;
    // Start is called before the first frame update
    void Start()
    {
        // add listeners to click events
        againBtn.onClick.AddListener(AgainBtn);
        menuBtn.onClick.AddListener(MenuBtn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AgainBtn()
    {
        if (PlayerPrefs.GetString("gameMode") == "race")
        {
            int levelNumber = PlayerPrefs.GetInt("level");
            if (levelNumber == 0)
            {
                // go to "Draw race" scene
                SceneManager.LoadScene("DrawRaceScene");
            }
            else
            {
                // go to "Race" scene
                SceneManager.LoadScene("NewRace");
            }
        }
        else
        {
            // go to "Autodrom" scene
            SceneManager.LoadScene("AutodromScene");
        }
    }

    void MenuBtn()
    {
        // go to "Main menu" scene
        SceneManager.LoadScene("MainMenu");
    }
}
