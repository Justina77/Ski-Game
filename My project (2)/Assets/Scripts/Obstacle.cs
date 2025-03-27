using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerCollision();
        }
    }

    private void PlayerCollision()
    {
        Debug.Log("Player hit" + name);
    }
}
