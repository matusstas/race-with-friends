using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDrawnRace : MonoBehaviour
{
    public GameObject DestroyAfterPlay;
    public GameObject UIRootObject;
    private AsyncOperation sceneAsync;

    public void Play()
    {
        // delete DestroyAfterPlay
        Destroy(DestroyAfterPlay);

        // Time.timeScale = 0; //pauses the current scene 
        // Application.LoadLevelAdditive("NewRace");
        // load new scene without destroying current one
        Application.LoadLevelAdditive("NewRace");
        // SceneManager.LoadScene("NewRace");

        


        // Scene sceneToLoad = SceneManager.GetSceneByName("NewRace");
        // SceneManager.MoveGameObjectToScene(UIRootObject, sceneToLoad);
        // StartCoroutine(loadScene("NewRace"));
    }

    // IEnumerator loadScene(string index)
    // {
    //     AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    //     scene.allowSceneActivation = false;
    //     sceneAsync = scene;

    //     //Wait until we are done loading the scene
    //     while (scene.progress < 0.9f)
    //     {
    //         Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
    //         yield return null;
    //     }
    //     //Activate the Scene
    //     sceneAsync.allowSceneActivation = true;


    //     Scene sceneToLoad = SceneManager.GetSceneByName(index);
    //     if (sceneToLoad.IsValid())
    //     {
    //         Debug.Log("Scene is Valid");
    //         SceneManager.MoveGameObjectToScene(UIRootObject, sceneToLoad);
    //         // get current scene
    //         Scene currentScene = SceneManager.GetActiveScene();

    //         SceneManager.SetActiveScene(sceneToLoad);
    //         SceneManager.UnloadSceneAsync("DrawRace");

    //         //destroy active scene

    //     }
    // }
}
