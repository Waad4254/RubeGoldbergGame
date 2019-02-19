using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public SteamVR_LoadLevel loadLevel;
    public int levelCollectables;
    private static int currentCollectables = 0;
    public PlatformController platform;

    public Transform initialLocation;
    private Rigidbody ballRb;
    private bool levelEnd = false;

    public AudioClip platformAudio;
    public AudioClip collectiblesAudio;


    private GameObject collectableParent;
    //private GameObject[] collectableObjects;

    private void Start()
    {
        ballRb = this.gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!levelEnd)
        {
            /*
            if (collision.gameObject.tag == "Collectable")
            {
                Debug.Log("One more Collectable");
                
                currentCollectables++;
                Debug.Log("currentCollectables" + currentCollectables);
                this.gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
                collision.gameObject.SetActive(false);


            }
            
            else */
            if (collision.gameObject.tag == "Goal")
            {
                Debug.Log("Reached the Goal");
                if (CIsComplete() && platform.IsStartAtPlatform())
                {
                    levelEnd = true;
                    Debug.Log("Worked !!");

                    //Load next level
                    collision.gameObject.GetComponent<AudioSource>().Play();
                    Debug.Log("Success -> nextLevel");
                    Debug.Log("currentCollectables" + currentCollectables);
                    loadLevel.Trigger();
                }
                else if (!platform.IsStartAtPlatform())
                {
                    Debug.Log("Fail -> Start at Platform");
                    Debug.Log("currentCollectables" + currentCollectables);
                    AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();//.Play();
                    audioSource.Play();
                    audioSource.PlayOneShot(platformAudio,1f);

                    Rest();
                }
                else if (!CIsComplete())
                {
                    Debug.Log("Fail -> Missing Collectables");
                    Debug.Log("currentCollectables" + currentCollectables);
                    AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();//.Play();
                    audioSource.Play();
                    audioSource.PlayOneShot(collectiblesAudio, 1f);
                    Rest();
                }

            }
            else if (collision.gameObject.tag == "Ground")
            {
                Debug.Log("Touched the ground -> reset");
                Debug.Log("currentCollectables"+ currentCollectables);
                this.gameObject.GetComponent<AudioSource>().Play();
                Rest();
            }
        }
    }

    public void Rest()
    {
        ballRb.position = initialLocation.position;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        currentCollectables = 0;

        collectableParent = GameObject.FindGameObjectWithTag("CollectibleParent");
        

         foreach (Transform child in collectableParent.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public bool CIsComplete()
    {
        return levelCollectables == currentCollectables;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Debug.Log("One more Collectable");

            currentCollectables++;
            Debug.Log("currentCollectables" + currentCollectables);
            this.gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
            collision.gameObject.SetActive(false);


        }
    }

}
