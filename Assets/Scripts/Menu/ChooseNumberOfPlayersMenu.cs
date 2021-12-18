using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class ChooseNumberOfPlayersMenu : MonoBehaviour
{
    public Button confirmBtn;
    // public GameObject inputField;

    public GameObject gameObjectInputField;
    public InputField inputField;
    public Button backBtn;

    // min and max number of players (included)
    public int minPlayers = 2;
    public int maxPlayers = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectInputField = GameObject.FindGameObjectWithTag("InputField");
        inputField = gameObjectInputField.GetComponent<InputField>();

        // listener to click event
        confirmBtn.onClick.AddListener(ConfirmBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);

        // inputField.text = PlayerPrefs.GetInt("numberOfPlayers", 2).ToString();
        inputField.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool ValidateInputField(string inputFieldText)
    {
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


    // on autodromBtn click
    public void ConfirmBtnClick()
    {
        if (ValidateInputField(inputField.text))
        {
            int numberOfPlayers = int.Parse(inputField.text);
            PlayerPrefs.SetInt("numberOfPlayers", numberOfPlayers);
            // load race scene
            // SceneManager.LoadScene("RaceScene");
            SceneManager.LoadScene("PlayScene");
        } else {
            Debug.Log("InputField: wrong number");
        }
    }

    public void BackBtnClick()
    {
        // load main menu scene
        // SceneManager.LoadScene("PlayScene");
        SceneManager.LoadScene("MainMenu");
    }
}
