using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    private ControllerMovement controller;
    
    ScoreManager instance = new ScoreManager();

    [SerializeField] private Text scoreText;

    public int score;
    public bool poweredUp = false;
    

    void Start()
    {
        controller = GetComponent<ControllerMovement>();
        score = instance.score;
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
            score += 1;
            scoreText.text = "TOTAL FRUITS: " + score.ToString();
        }
        if (other.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            score += 1;
            poweredUp = true;
            controller.speed = 12f;
            scoreText.text = "TOTAL FRUITS: " + score.ToString();
        }
        
    }
}
