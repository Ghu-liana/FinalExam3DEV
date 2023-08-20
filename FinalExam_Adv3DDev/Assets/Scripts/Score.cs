using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI score;
    public PlayerAction script;


    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int collectCount = script.collectCount;
        string text = collectCount.ToString("F0");
        score.text = "Total Fruits: " + text;

    }
}
