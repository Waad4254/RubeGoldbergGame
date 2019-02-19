using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{

    // Use this for initialization
    public Transform initialLocation;
    private Rigidbody ballRb;

    private void Start()
    {
        ballRb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("ENTER OnCollisionEnter ~ Ground");
            RestBall();
        }
    }

    public void RestBall()
    {
        ballRb.position = initialLocation.position;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }
}
