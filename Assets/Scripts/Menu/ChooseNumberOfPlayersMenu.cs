using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseNumberOfPlayersMenu : MonoBehaviour
{
    public Button confirmBtn;
    // public GameObject inputField;

    public GameObject gameObjectInputField;
    public InputField inputField;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectInputField = GameObject.FindGameObjectWithTag("InputField");
        inputField = gameObjectInputField.GetComponent<InputField>();

        // listener to click event
        confirmBtn.onClick.AddListener(ConfirmBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);

        inputField.text = PlayerPrefs.GetInt("numberOfPlayers", 2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool ValidateInputField()
    {
        PlayerPrefs.SetInt("numberOfPlayers", int.Parse(inputField.text));
        return true;
    }


    // on autodromBtn click
    public void ConfirmBtnClick()
    {
        if (ValidateInputField())
        {
            // load race scene
            SceneManager.LoadScene("RaceScene");
        } else {
            Debug.Log("InputField: wrong number");
        }
    }

    public void BackBtnClick()
    {
        // load main menu scene
        SceneManager.LoadScene("PlayScene");
    }
}
