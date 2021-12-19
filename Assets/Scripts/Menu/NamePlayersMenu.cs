using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NamePlayersMenu : MonoBehaviour
{
    public Button submitBtn;
    public Button backBtn;

    private int carCount;

    public InputField inputField;

    public List<InputField> inputFields = new List<InputField>();
    

    void Awake()
    {
        carCount = PlayerPrefs.GetInt("numberOfPlayers");
        Debug.Log("carCount: " + carCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        submitBtn.onClick.AddListener(SubmitBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

        // zatial pre race

        int offset = 80;
        if (PlayerPrefs.GetString("mode") == "all")
        {
            for (int i = 0; i < carCount; i++)
            {
                inputFields.Add(Instantiate(inputField, new Vector3(960,800-(i*offset+offset),0), Quaternion.identity, canvas.transform));            
                if (Global.carNames.Count > i)
                {
                    inputFields[i].text = Global.carNames[i];
                } else {
                    inputFields[i].text = "Car " + i;
                }
            }
        } else
        {
            int indexTeam1 = 0;
            int indexTeam2 = 0;
            for (int i = 0; i < carCount; i++)
            {
                string carName;
                if (Global.carNames.Count > i)
                {
                    carName = Global.carNames[i];
                } else {
                    carName = "Car " + i;
                }

                if (i%2 == 0)
                {
                    inputFields.Add(Instantiate(inputField, new Vector3(300,800-(indexTeam1*offset+offset),0), Quaternion.identity, canvas.transform));
                    indexTeam1++;
                } else 
                {
                    inputFields.Add(Instantiate(inputField, new Vector3(700,800-(indexTeam2*offset+offset),0), Quaternion.identity, canvas.transform));
                    indexTeam2++;
                }

                inputFields[i].text = carName;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitBtnClick()
    {
        Global.carNames.Clear();
        foreach (InputField inputField in inputFields)
        {
            Global.carNames.Add(inputField.text);
        }

        if (PlayerPrefs.GetString("gameMode") == "autodrom")
        {
            SceneManager.LoadScene("AutodromScene");
        } else 
        {
            SceneManager.LoadScene("RaceScene");
        }
    }

    public void BackBtnClick()
    {
        Global.carNames.Clear();
        foreach (InputField inputField in inputFields)
        {
            Global.carNames.Add(inputField.text);
        }
        // Load autodrom scene

        if (PlayerPrefs.GetString("gameMode") == "autodrom")
        {
            SceneManager.LoadScene("AutodromMenuScene");        
        } else
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

}
