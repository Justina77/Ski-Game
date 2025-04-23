using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private List<Text> timeTexts;
    [SerializeField] private LeaderBoard leaderboard;

    private void OnEnable()
    {
        UpdateLeaderboardUI();
    }

    public void UpdateLeaderboardUI()
    {
        List<float> bestTimes = leaderboard.GetBestTimes();

        for (int i = 0; i < timeTexts.Count; i++)
        {
            if (i < bestTimes.Count)
            {
                float time = bestTimes[i];
                int minutes = Mathf.FloorToInt(time / 60f);
                float seconds = time % 60f;
                timeTexts[i].text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
            }
            else
            {
                timeTexts[i].text = "--:--.--";
            }
        }
    }
}
