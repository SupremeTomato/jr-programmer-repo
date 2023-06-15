using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider scoreCollider;
    public int score= 0;

    void Start()
    {
        scoreCollider = GameObject.Find("Trigger").GetComponent<BoxCollider>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

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
    void UpdateScore()
    {
        
        Debug.Log("Score: " + score);

    }
}
