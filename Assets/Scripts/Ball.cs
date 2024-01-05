using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float STARTING_SPEED = 5f;

    public float Speed = STARTING_SPEED;
    public AudioClip HitPlayerClip;
    public AudioClip HitWallClip;
    public AudioClip ScoreClip;

    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * Speed, ForceMode2D.Impulse);
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        Speed = STARTING_SPEED;
    }

    private void FixedUpdate()
    {
        // Take into account increases in speed 
        Vector2 direction = _rigidbody.velocity.normalized;
        _rigidbody.velocity = direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip sound = null;

        switch(collision.gameObject.tag)
        {
            case "Player":
                sound = HitPlayerClip; break;
            case "Wall":
                sound = HitWallClip; break;
            case "Score":
                sound = ScoreClip; break;
        }
        _audioSource.PlayOneShot(sound);
    }

}
