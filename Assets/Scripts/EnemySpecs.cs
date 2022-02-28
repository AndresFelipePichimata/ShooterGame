using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecs : MonoBehaviour
{
    [SerializeField] float hp;
    Transform transform;
    Rigidbody2D body;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        float newSpeed;
        body.velocity = new Vector2(speed, body.velocity.y);
        Debug.Log("x: " + transform.position.x);
        
        if (transform.position.x >= 15)
        {
            newSpeed = Math.Abs(speed) * (-1);
            speed = newSpeed;
        }
        if (transform.position.x <= -9.5)
        {
            speed = Math.Abs(speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject go = other.gameObject;
        if (go.tag == "Bullet")
        {
            hp--;
        }
        if (hp == 0 || go.tag == "ChargedBullet")
        {
            Destroy(this.gameObject);
        }
    }
}
