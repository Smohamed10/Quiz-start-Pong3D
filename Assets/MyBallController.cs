using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBallController : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    private Rigidbody rb;

    private bool stopped = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //
        //direction = new Vector3(0.5f, 0, 0.5f);
        SetRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void startMove()
    {
        stopped = false;
        SetRandomDirection();
    }

    public void stopMove()
    {
        stopped = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }
        if(other.CompareTag("Racket"))
        {
            direction.x = -direction.x;
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            direction = newDirection;
        }
        direction.y = 0;
    }

    private void SetRandomDirection()
    {
        float x = Random.value;
       
        float z= Random.value;
        direction=new Vector3(x, 0, z).normalized;
    }
}
