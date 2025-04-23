using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();
    public List<float> BestTimes => bestTimes;

    private void Awake()
    {
        bestTimes.Clear();
        int racesCompleted = PlayerPrefs.GetInt("racesCompleted", 0);

        for (int i = 0; i < 5; i++)
        {
            float time = PlayerPrefs.GetFloat("time" + i, 999999f);
            if (time < 999999f)
                bestTimes.Add(time);
        }

        if (racesCompleted == 0)
        {
            // Очистка PlayerPrefs перед первым забегом
            for (int i = 0; i < 5; i++)
                PlayerPrefs.DeleteKey("time" + i);
        }
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();

        if (bestTimes.Count > 5)
            bestTimes.RemoveAt(bestTimes.Count - 1);

        SaveData();

        // Увеличиваем количество завершённых забегов
        int completed = PlayerPrefs.GetInt("racesCompleted", 0);
        PlayerPrefs.SetInt("racesCompleted", completed + 1);
        PlayerPrefs.Save();
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
                PlayerPrefs.SetFloat("time" + i, bestTimes[i]);
            else
                PlayerPrefs.SetFloat("time" + i, 999999f);
        }
    }

    public List<float> GetBestTimes()
    {
        return new List<float>(bestTimes);
    }
}
