using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private bool timerRunning =false;
    private float raceTime = 0;
    [SerializeField] private float penaltyTime = 1;
    [SerializeField] private LeaderBoard Leaderboard;

    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }

    private void OnEnable()
    {
        GameEvents.raceStart += StartRace;
        GameEvents.raceEnd += FinishRace;
        GameEvents.racePenalty += Penalty;
    }

    private void OnDisable()
    {
        GameEvents.raceStart -= StartRace;
        GameEvents.raceEnd -= FinishRace;
        GameEvents.racePenalty -= Penalty;
    }

    private void Penalty()
    {
        raceTime += penaltyTime;
        Debug.Log("penalty recieved!");
    }

    private void StartRace()
    {
        raceTime = 0;
        timerRunning = true;
        Debug.Log("Race started!");
    }

    private void FinishRace()
    {
        timerRunning = false;
        Leaderboard.AddTime(raceTime);
        GameData.Instance.racesCompleted++;
        Debug.Log("Race completed:" + GameData.Instance.racesCompleted);
        Debug.Log("Race finished!");
        Debug.Log("race time: " + raceTime);
    }
}
