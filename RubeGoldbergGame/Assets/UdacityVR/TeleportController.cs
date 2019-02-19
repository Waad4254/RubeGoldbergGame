using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {

    private Rigidbody ballRB;
    public GameObject teleportD;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            collision.transform.position = teleportD.gameObject.transform.position;
            collision.transform.rotation = teleportD.gameObject.transform.rotation;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(teleportD.gameObject.transform.forward *200);
            this.gameObject.GetComponent<AudioSource>().Play();
        }

    }
}
