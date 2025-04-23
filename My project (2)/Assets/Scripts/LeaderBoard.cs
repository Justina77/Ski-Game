using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private List<float> bestTimes = new();

    public List<float> BestTimes => bestTimes;

    private void Awake()
    {
        // PlayerPrefs.DeleteAll(); 
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            float savedTime = PlayerPrefs.GetFloat("time" + i, -1f);
            if (savedTime >= 0f)
                bestTimes.Add(savedTime);
        }
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        if (bestTimes.Count > 5)
            bestTimes.RemoveAt(bestTimes.Count - 1);
        SaveData();
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
                PlayerPrefs.SetFloat("time" + i, bestTimes[i]);
            else
                PlayerPrefs.DeleteKey("time" + i);
        }
        PlayerPrefs.Save();
    }

    public List<float> GetBestTimes()
    {
        return new List<float>(bestTimes);
    }
}
