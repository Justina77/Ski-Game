using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerEvents.onHitEvent += TakeDmg;
    }

    private void OnDisable()
    {
        PlayerEvents.onHitEvent -= TakeDmg;
    }

    private void TakeDmg()
    {
        Debug.Log("player took damage");
    }
}
