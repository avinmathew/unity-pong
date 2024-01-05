using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float BounceStrength = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            // Increase speed on collision
            ball.Speed += BounceStrength;
        }
    }
}
