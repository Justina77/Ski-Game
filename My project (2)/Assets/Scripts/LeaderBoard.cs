using System;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void DontDestroyOnLand(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
    }


}
