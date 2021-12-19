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
        carCount = PlayerPrefs.GetInt("numberOfPlayers", 2);
        Debug.Log("carCount: " + carCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        // listener to click event
        submitBtn.onClick.AddListener(SubmitBtnClick);
        backBtn.onClick.AddListener(BackBtnClick);

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

        // race
        if (PlayerPrefs.GetString("mode") == "all")
        {
            for (int i = 0; i < carCount; i++)
            {
                GameObject inputFieldObj = Instantiate(inputField.gameObject, canvas.transform);
                inputFieldObj.transform.position = calculatePosition(1, 0, i);
                inputFields.Add(inputFieldObj.GetComponent<InputField>());
                inputFields[i].text = generateCarName(i);
            }
        }
        else
        {
            for (int i = 0; i < carCount; i++)
            {
                GameObject inputFieldObj = Instantiate(inputField.gameObject, canvas.transform);
                inputFieldObj.transform.position = calculatePosition(2, i % 2, i);
                inputFields.Add(inputFieldObj.GetComponent<InputField>());
                inputFields[i].text = generateCarName(i);
            }
        }
    }

    // get name from Global.carNames if exists fron index
    // else return "Car " + index
    private string generateCarName(int index)
    {
        if (Global.carNames.Count > index)
        {
            return Global.carNames[index];
        }
        else
        {
            return "Car " + index;
        }
    }


    private Vector2 calculatePosition(int numberOfColumns, int columnIndex, int rowIndex)
    {
        // set offset based on i
        float paddingY = Screen.height / 5;
        float paddingX = Screen.height / 3;

        float offsetY = Mathf.Ceil(rowIndex / numberOfColumns) * Screen.height / 15 + paddingY;
        float offsetX;

        if (numberOfColumns == 1)
        {
            offsetX = 0;
        }
        else
        {
            if (columnIndex == 0)
            {
                offsetX = paddingX;
            }
            else
            {
                offsetX = -paddingX;
            }
        }
        return new Vector2(Screen.width / 2 - offsetX, Screen.height - offsetY);
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
        }
        else
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
        }
        else
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

}
