using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayDrawnRace : MonoBehaviour
{
    public GameObject DestroyAfterPlay;
    public GameObject UIRootObject;
    private AsyncOperation sceneAsync;

    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        backBtn.onClick.AddListener(BackBtnClick);
    }

    public void Play()
    {
        // delete DestroyAfterPlay
        Destroy(DestroyAfterPlay);

        // load new scene without destroying current one
        Application.LoadLevelAdditive("NewRace");
    }

    public void BackBtnClick()
    {
        // load main menu scene
        SceneManager.LoadScene("RaceScene");
    }
}
