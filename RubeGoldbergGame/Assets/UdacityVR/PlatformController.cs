using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    // Use this for initialization
    private bool atPlatformStart = false;
    private bool playerAtPlatform = false;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Debug.Log("Ball Exit The Platform");

            atPlatformStart = true;
        }

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player Exit The Platform");
            playerAtPlatform = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Enter The Platform");
            playerAtPlatform = true;
        }

        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("Ball Enter The Platform");
            atPlatformStart = false;
        }
    }

    public bool IsStartAtPlatform()
    {
        Debug.Log("atPlatformStart"+ atPlatformStart);
        Debug.Log("playerAtPlatform"+ playerAtPlatform);
        return (atPlatformStart && playerAtPlatform);
    }
}
