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
        for (int i = 0; i < carCount; i++)
        {
            inputFields.Add(Instantiate(inputField, new Vector3(500,500-(i*30+30),0), Quaternion.identity, canvas.transform));            
            if (Global.carNames.Count > i)
            {
                inputFields[i].text = Global.carNames[i];
            } else {
                inputFields[i].text = "Car " + i;
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

        // Load play scene
        SceneManager.LoadScene("AutodromScene");
    }

    public void BackBtnClick()
    {
        Global.carNames.Clear();
        foreach (InputField inputField in inputFields)
        {
            Global.carNames.Add(inputField.text);
        }
        // Load autodrom scene
        SceneManager.LoadScene("AutodromMenuScene");
    }

}
