using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCrontrol : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;

    public float upSpeed;
    public float sideSpeed;
    public float topSpeed;

    public float ciel;

    public float gravity;
    private float baseGrav;
    public float gravFactor;

    public bool falling;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        baseGrav = gravity;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
       
        var pos = transform.position;


        if (pos.y == 0)
        {
            falling = false;
        }
        else
        {
            falling = true;
        }


        if (Input.GetKey(KeyCode.D))
            pos.x += sideSpeed;
        if (Input.GetKey(KeyCode.A))
            pos.x -= sideSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += upSpeed;
            falling = false;
        }

        if (falling)
        {
            gravity = gravity * gravFactor;
        }
        else
        {
            gravity = baseGrav;
        }

        pos.y -= gravity;


        pos.y = Mathf.Clamp(pos.y, 0, ciel);

        transform.position = pos;

    
    }
}
