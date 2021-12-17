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
        // load main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
