using UnityEngine;

public class ExplodingObstacle : Obstacle
{
    protected override void PlayerCollision()
    {
        base.PlayerCollision();
        Destroy(gameObject);
    }
}
