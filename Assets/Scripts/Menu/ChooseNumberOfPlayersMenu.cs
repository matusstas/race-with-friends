using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ChooseNumberOfPlayersMenu : MonoBehaviour
{
    // The goal is to select the number of players
    
    public Button confirmBtn;
    public Button backBtn;
    public GameObject gameObjectInputField;
    public InputField inputField;
    public int minPlayers = 2;
    public int maxPlayers = 10;

    // Start is called before the first frame update
    void Start()
    {
        // load input field and set it up
        gameObjectInputField = GameObject.FindGameObjectWithTag("InputField");
        inputField = gameObjectInputField.GetComponent<InputField>();
        inputField.text = "";

        // add listeners to click events
        confirmBtn.onClick.AddListener(ConfirmBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool ValidateInputField(string inputFieldText)
    {
        // validate input by matching only numbers
        // if matched number is in specific range (min-max incluced) return true
        
        Regex regex = new Regex(@"^\d+$");
        if (regex.IsMatch(inputFieldText))
        {
            int numberOfPlayers = int.Parse(inputFieldText);
            if (numberOfPlayers >= minPlayers && numberOfPlayers <= maxPlayers)
            {
                return true;
            } else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }

    public void ConfirmBtnClick()
    {
        // when clicking on confirm button make sure the input is valid
        // if it is, set assigned number of player for the game and load next scene

        if (ValidateInputField(inputField.text))
        {
            int numberOfPlayers = int.Parse(inputField.text);
            PlayerPrefs.SetInt("numberOfPlayers", numberOfPlayers);
            SceneManager.LoadScene("PlayScene");
        } else {
            Debug.Log("InputField: wrong number");
        }
    }

    public void BackBtnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
