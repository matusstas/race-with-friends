using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayDrawnRace : MonoBehaviour
{
    public GameObject[] DestroyAfterPlay;
    public GameObject UIRootObject;
    private AsyncOperation sceneAsync;

    public Button backBtn;

    // public GameObject drawnRace;

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        backBtn.onClick.AddListener(BackBtnClick);
    }

    public void Play()
    {
        // destroy all objects that should be destroyed after play
        foreach (GameObject obj in DestroyAfterPlay)
        {
            Destroy(obj);
        }

        // loop all GameObjects in the scene and if they have a CopyObject, destroy them
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            Debug.Log("obj: " + obj.name);
            if (obj.GetComponent<CopyObject>() != null)
            {
                Destroy(obj);
            }

            // if object has a DragAndDrop script, destroy that script
            if (obj.GetComponent<DragAndDrop>() != null)
            {
                Destroy(obj.GetComponent<DragAndDrop>());
            }

            // if object has a DrawPath script, destroy that script
            if (obj.GetComponent<DrawPath>() != null)
            {
                Destroy(obj.GetComponent<DrawPath>());
            }
        }

        // // create copy of drawnRace and disable it
        // GameObject copy = Instantiate(drawnRace);
        // copy.SetActive(false);
        // copy.name = "DrawnRaceCopy";


        // load new scene without destroying current one
        Application.LoadLevelAdditive("NewRace");
    }

    public void BackBtnClick()
    {
        // load main menu scene
        SceneManager.LoadScene("RaceScene");
    }
}
