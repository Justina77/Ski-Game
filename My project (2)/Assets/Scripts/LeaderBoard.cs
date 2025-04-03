using System;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();

    private void Awake()
    {
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            bestTimes.Add(PlayerPrefs.GetFloat("time" + i, 9999999999));
        }
    }

    private void DontDestroyOnLand(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveData();
    }

    private void SaveData()
    {
        for(int i=0; i<5; i++)
        {
            if(i<bestTimes.Count)
            PlayerPrefs.SetFloat("time"+i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }

}
