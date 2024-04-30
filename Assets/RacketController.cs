using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode up;
    public KeyCode down;
    public Rigidbody rb;
    public bool isPlayer;
    private Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = true;
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }
    // Update is called once per frame
    void Update()
    {
       if(isPlayer)
        {
            moveByPlayer();
        }
        else { moveByComputer(); }
    }

    private void moveByComputer()
    {
        if(ball.position.z > transform.position.z)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if(ball.position.z < transform.position.z)
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }
    private void moveByPlayer()
    {
        bool isUp = Input.GetKey(up);
        if (isUp)
        {
            rb.velocity = Vector3.forward * speed;
        }
        bool isDown = Input.GetKey(down);
        if (isDown)
        {
            rb.velocity = Vector3.back * speed;
        }
        if (!isDown && !isUp)
        {
            rb.velocity = Vector3.zero;
        }

    }
}
