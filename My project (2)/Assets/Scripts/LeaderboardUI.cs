using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> timeTexts;
    [SerializeField] private LeaderBoard leaderboard;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < timeTexts.Count; i++)
        {
            if (i < leaderboard.BestTimes.Count)
            {
                timeTexts[i].text = FormatTime(leaderboard.BestTimes[i]);
            }
            else
            {
                timeTexts[i].text = "---";
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
    }
}