using UnityEngine;

public class PenaltyFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameEvents.CallRacePenalty();
    }
}
