using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class objectMenuManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    private int currentObject = 0;

    public List<int> quantity;

    public SteamVR_Action_Vector2 swapMenu;
    public SteamVR_Action_Boolean menuDisplay;
    public SteamVR_Action_Boolean spawn;



    private float swipeSum;
    private bool hasSwipedLeft = false;
    private bool hasSwipedRight = false;


    void Start () {

 
        foreach (Transform child in transform)
        {
           
            objectList.Add(child.gameObject);

        }
        // child.transform.FindChild("text").gameObject.GetComponent<Text>().text = "Quantity : "+ quantity[];

        for(int i = 0; i< objectList.Count; i++)
        {
            objectList[i].transform.Find("canvas").gameObject
                .transform.Find("text").gameObject.GetComponent<Text>().text = "Quantity : " + quantity[i];
        }
    }

    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
            currentObject = objectList.Count-1;

        objectList[currentObject].SetActive(true);
    }

    public void MenuRight()
    {

        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count - 1)
            currentObject = 0;

        objectList[currentObject].SetActive(true);

    }
    public void MenuLock()
    {
        objectList[currentObject].SetActive(false);
    }

    public bool IsActive()
    {
        return objectList[currentObject].active;
    }

    public void SpawnCurrentObject()
    {
        if (quantity[currentObject] > 0)
        {
            Instantiate(objectPrefabList[currentObject],
            objectList[currentObject].transform.position,
            objectList[currentObject].transform.rotation);
            quantity[currentObject]--;

            objectList[currentObject].transform.Find("canvas").gameObject
                .transform.Find("text").gameObject.GetComponent<Text>().text = "Quantity : " + quantity[currentObject];
        }
        else
        {
            Debug.Log("Object not available");
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

      if (menuDisplay.stateUp)
       {
            swipeSum = 0;
            hasSwipedLeft = false;
            hasSwipedRight = false;
            MenuLock();
      }

            swipeSum = swapMenu.GetAxis(SteamVR_Input_Sources.RightHand).x;

            Debug.Log(swipeSum);

            if (swipeSum > -0.2f && swipeSum < 0.2f)
            {
                swipeSum = 0;
                hasSwipedLeft = false;
                hasSwipedRight = false;
            }


            if (!hasSwipedRight)
            {
                if (swipeSum >= 0.2f )
                {
                    swipeSum = 0;
                    MenuRight();
                    hasSwipedLeft = false;
                    hasSwipedRight = true;
                }
            }
            if (!hasSwipedLeft)
            {
                if (swipeSum <= -0.2f)
                {
                    swipeSum = 0;
                    MenuLeft();
                    hasSwipedLeft = true;
                    hasSwipedRight = false;
                }
            }

            if (spawn.stateDown && IsActive())
            {            
                SpawnCurrentObject();
                swipeSum = 0;
                hasSwipedLeft = false;
                hasSwipedRight = false;
                MenuLock();         
            }
    }
}
