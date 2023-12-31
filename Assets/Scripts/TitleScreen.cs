using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public TMP_InputField nameField;

    private TextMeshProUGUI errorMessage;

    //ENCAPSULATION
    private string InternalUsername;
    public string username
    {
        get { return InternalUsername; }
        set { InternalUsername = value; }
    }


    private void Start()
    {
        errorMessage = GameObject.Find("Error Message").GetComponent<TextMeshProUGUI>();
        //StartCoroutine(SceneLoader());
    }
    public void setUsername(string str)
    {
        if (str.Any(char.IsDigit))
        {
            errorMessage.enabled = true;
            StartCoroutine(errorMessageTimer());
            
            nameField.text = "";
        }
        else
        {
            errorMessage.enabled = false;
            username = str;
            NewPlayerName(username);
            StartCoroutine(SceneLoader());

        }
    }

    IEnumerator errorMessageTimer()
    {
        yield return new WaitForSeconds(3);

        errorMessage.enabled = false;
    }
    IEnumerator SceneLoader()
    {
            Debug.Log("Loading scene 1");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(1);
            
    }

    public void NewPlayerName(string name)
    {
        SaveName.Instance.playerName = name;
    }

}
