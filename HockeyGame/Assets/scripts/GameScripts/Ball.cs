using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody2D _ballRb;
    public ParticleSystem ballParticle;
    Vector2 LastVelovity;
    public static GameObject _goalSide;
    public static bool goal;

    void Start()
    {
        ballParticle.Stop();
    }
    void Update()
    {
        if (GameManager.gamePause)
        {
            _ballRb.drag = 10;
        }
        else
        {
            _ballRb.drag = 0.3f;
        }
        LastVelovity = _ballRb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            float _ballSpeed = LastVelovity.magnitude;
            Vector2 direction = Vector2.Reflect(LastVelovity.normalized, collision.GetContact(0).normal);
            _ballRb.velocity = direction * Mathf.Max(_ballSpeed - 1f, 0f);
            ballParticle.Play();      
        }
        if (collision.gameObject.CompareTag("OutOfRange"))
        {
            goal = true;
            _goalSide = collision.gameObject;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal = true;
            Destroy(this.gameObject);
            _goalSide = collision.gameObject;
        }
    }
}
