using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject bullet;

    [SerializeField] GameObject charged;

    private float fireRate = 1f;

    private float nextFire = 0f;

    private float minX, maxX, minY, maxY;

    private float shoot = -1f;

    public float downTime, pressTime = 0;

    public float countDown = 3.0f;

    public bool ready = false;

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

        if (Input.GetKeyDown(KeyCode.X))
        {

            shoot = shoot * (-1f);

        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && shoot==-1f)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, transform.rotation);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && shoot == 1f && ready == false)
        {
            
            downTime = Time.time;
            pressTime = downTime + countDown;
            ready = true;

        }

        if (Time.time >= pressTime && ready == true && Input.GetKeyUp(KeyCode.Space))
        {
            ready = false;
            nextFire = Time.time + fireRate;
            Instantiate(charged, transform.position, transform.rotation);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ready = false;
        }

    }
}
