using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject bullet;

    private float fireRate = 1f;

    private float nextFire = 0f;

    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esqInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        minX = esqInfIzq.x;
        minY = esqInfIzq.y;

        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(dirH*speed*Time.deltaTime, dirV*speed*Time.deltaTime));
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY/2, maxY)
        );

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
