using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Transform transform;
    float currentTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        randomVelocity();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime+Time.deltaTime;
        if (currentTime > 4)
        {
            randomVelocity();
            currentTime = 0;
        }
        if(transform.position.x > 9 || transform.position.x < -9)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        if (transform.position.y > 4 || transform.position.y < -4)
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }



    }

    private void OnMouseDown()
    {
        scaleUp();
        
    }
    private void OnMouseUp()
    {
        NormalScale();
    }
    private void OnTouchDown()
    {
        scaleUp();
    }
    void OnTouchUp()
    {
        NormalScale();
    }
    void randomVelocity()
    {
        rb.velocity = new Vector2(Random.Range(-0.6f, 0.6f), Random.Range(-0.6f, 0.6f));
    }
    void scaleUp()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    void NormalScale()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
