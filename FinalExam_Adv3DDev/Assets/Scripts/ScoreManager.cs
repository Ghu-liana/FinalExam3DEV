using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    
    public int score;
    

    private void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        score = 0;   
    }

}
