using UnityEngine;

public class LeftPaddle : Paddle
{
    private void Update()
    {
        // Left is always human player
        if (Input.GetKey(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }
}
