using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private GameObject _ball;
    private Rigidbody2D _botRB;
    float newX;
    void Start()
    {
        _botRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _ball = GameObject.FindWithTag("Ball");
        if (_ball.transform.position.x <= 0)
        {
            Vector3 PosBoll = new Vector3(_ball.transform.position.x - 1.3f, _ball.transform.position.y, _ball.transform.position.z);
            _botRB.transform.position = Vector3.MoveTowards(transform.position, PosBoll, MenuConfig.botVelocity);
        }
        else
        {
            Vector3 PosBoll = new Vector3(transform.position.x, _ball.transform.position.y, _ball.transform.position.z);
            _botRB.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, PosBoll.y, transform.position.z), MenuConfig.botVelocity);
        }
        if (transform.position.y >= 3.8f)
        {
            transform.position = new Vector2(transform.position.x, 3.8f);
        }
        if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector2(transform.position.x, -3.8f);
        }
        if (transform.position.x >= -0.05f)
        {
            transform.position = new Vector2(-0.05f, transform.position.y);
        }
        if (transform.position.x <= -7.15f)
        {
            transform.position = new Vector2(-7.15f, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector2 awayPlayer = _ball.transform.position - transform.position;
            _ball.GetComponent<Rigidbody2D>().velocity = awayPlayer * MenuConfig.botForce; // - new Vector2(transform.position.x, transform.position.y) * botForce;
        }
    }
}
