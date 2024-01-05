using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 25f;

    protected Rigidbody2D _rigidbody;
    protected Vector2 _direction;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        _rigidbody.position = new Vector2(_rigidbody.position.x, 0);
        _rigidbody.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (GameManager.IsGameStarted)
        {
            if (_direction.sqrMagnitude != 0)
            {
                _rigidbody.AddForce(_direction * this.Speed);
            }
        }
    }
}
