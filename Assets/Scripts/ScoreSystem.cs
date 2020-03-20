using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private CrystalCollector crystalCollector;
    private int currentScore;
    private int CurrentScore
    { 
            get => currentScore; 
            set 
            { 
                currentScore = value;
                RecordScore = (currentScore > RecordScore ? currentScore : RecordScore);
                ScoreUpdated?.Invoke(currentScore);
            }
    }
    private int RecordScore { get; set; }

    public event UnityAction<int> ScoreUpdated;

    private void OnEnable()
    {
        crystalCollector.CrystalCollected += OnCrystalCollected;

        // По хорошему стоит перенести это в отдельный класс, но в данном случае можно оставить и так.
        RecordScore = PlayerPrefs.GetInt("RecordScore", 0);
    }

    private void OnDisable()
    {
        crystalCollector.CrystalCollected -= OnCrystalCollected;

        // По хорошему стоит перенести это в отдельный класс, но в данном случае можно оставить и так.
        PlayerPrefs.SetInt("RecordScore", RecordScore);
    }
    private void OnCrystalCollected(int revard)
    {
        CurrentScore += revard;   
    }
}
