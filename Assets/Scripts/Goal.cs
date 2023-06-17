using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Easy"))
        {
            gameManager.score += 1;
            gameManager.UpdateScore();
        }
        else if (other.CompareTag("Mid"))
        {
            gameManager.score += 2;
            gameManager.UpdateScore();
        }
        else if (other.CompareTag("Hard"))
        {
            gameManager.score += 3;
            gameManager.UpdateScore();
        }
    }
}
