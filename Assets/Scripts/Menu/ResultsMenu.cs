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
                SceneManager.LoadScene("DrawRaceScene");
            }
            else
            {
                SceneManager.LoadScene("NewRace");
            }
        }
        else
        {
            SceneManager.LoadScene("AutodromScene");
        }
    }

    void MenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
