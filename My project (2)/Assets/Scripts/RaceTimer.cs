using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private bool timerRunning =false;
    private float raceTime = 0;
    [SerializeField] private float penaltyTime = 1;

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
        timerRunning = true;
        Debug.Log("Race started!");
    }

    private void FinishRace()
    {
        timerRunning = false;
        Debug.Log("Race finished!");
        Debug.Log("race time: " + raceTime);
    }
}
