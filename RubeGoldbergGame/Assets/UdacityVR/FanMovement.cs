using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMovement : MonoBehaviour {

    // Use this for initialization
    public int speed = 500;
    public float force = 500;

	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0f, 0f, Time.deltaTime * speed);	
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay ~ Fan Force");
        // Vector3 direction = new Vector3(0f,0f,500);
        //Debug.Log("OnTriggerStay ~ Fan Force"+ direction);
        if (other.gameObject.tag == "Ball")
        {
            other.GetComponent<Rigidbody>()
            .AddForce(transform.forward * force);
        }
    }
}
