using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTwo : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float maxVelocity = 1f;
    public float playerForce = 5f;

    void LateUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x - 1.5f, touch.position.y - 0.5f));
            if (pos.x < -0.05)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos, maxVelocity);
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector2 awayPlayer = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = awayPlayer * playerForce; //- new Vector2(transform.position.x, transform.position.y) * playerForce;
        }
    }
}
