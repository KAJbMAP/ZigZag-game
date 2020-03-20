using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class UIScoreUpdater : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public ScoreSystem scoreSystem;

    private void OnEnable()
    {
        scoreSystem.ScoreUpdated += OnScoreUpdated;
    }

    private void OnDisable()
    {
        scoreSystem.ScoreUpdated -= OnScoreUpdated;
    }

    private void OnScoreUpdated(int score)
    {
        if (ScoreText)
            ScoreText.SetText(score.ToString());
    }
    
}
