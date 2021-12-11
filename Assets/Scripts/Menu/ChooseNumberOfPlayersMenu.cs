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

    // Start is called before the first frame update
    void Start()
    {
        gameObjectInputField = GameObject.FindGameObjectWithTag("InputField");
        inputField = gameObjectInputField.GetComponent<InputField>();

        // listener to click event
        confirmBtn.onClick.AddListener(ConfirmBtnClick);
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
}
