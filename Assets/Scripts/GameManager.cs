using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private BoxCollider scoreCollider;
    public TextMeshProUGUI scoreText;
    public SaveName saveNameScript;

    public int score= 0;

    void Start()
    {
        //scoreCollider = GameObject.Find("Trigger").GetComponent<BoxCollider>();
        saveNameScript = GameObject.Find("PlayerData").GetComponent<SaveName>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Easy"))
        {
            score += 1;
            UpdateScore();
        }
        else if (other.CompareTag("Mid"))
        {
            score += 2;
            UpdateScore();
        }
        else if (other.CompareTag("Hard"))
        {
            score += 3;
            UpdateScore();
        }
    }
    */

    public void UpdateScore()
    {
        scoreText.text = saveNameScript.playerName + " Score: " + score;
        Debug.Log("Score: " + score);

    }
    
}
