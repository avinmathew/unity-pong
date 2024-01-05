using UnityEngine;

public class RightPaddle : Paddle
{
    public Rigidbody2D Ball;

    private void Update()
    {
        if (GameManager.NumberOfPlayers == 1)
        {
            // Computer player
            if (Ball.velocity.x > 0)
            {
                // When ball is coming toward player
                // Track the position of the ball
                _direction = Ball.position.y > transform.position.y ? Vector2.up : Vector2.down;
            }
            else
            {
                // When ball is coming toward computer
                // Drift toward centre
                _direction = transform.position.y > 0f ? Vector2.down : Vector2.up;
            }
        }
        else
        {
            // Human player
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                _direction = Vector2.down;
            }
            else
            {
                _direction = Vector2.zero;
            }
        }
    }
}
