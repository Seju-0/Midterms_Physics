using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float baseSpeed = 1f;
    public float maxSpeed = 10f;
    public float acceleration = 2f;
    public float currentSpeed;

    private Vector3 direction;
    private float tiltAngle = 200f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, baseSpeed, acceleration * Time.deltaTime);
        }
        transform.position += new Vector3(currentSpeed * Time.deltaTime, 0f, 0f);

        if(Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(1f, Mathf.Tan(tiltAngle * Mathf.Deg2Rad), 0f).normalized;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = new Vector3(1f, -Mathf.Tan(tiltAngle * Mathf.Deg2Rad), 0f).normalized;
        }
        else
        {
            direction = Vector3.right;
        }
        transform.position += direction * currentSpeed * Time.deltaTime;
    }

}
