using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExpectationController : MonoBehaviour {
    public List<string> partsSteppedOn = new List<string>();
    [HideInInspector]public string expectation;

    void OnEnable()
    {
        EventManager.StartListening("expectation", Expectation);
    }
    void OnDisable()
    {
        EventManager.StopListening("expectation", Expectation);
    }
	// Update is called once per frame
	void Update () {
        if(partsSteppedOn.Count > 7)
        {
            partsSteppedOn.RemoveAt(0);
        }
	}

    void Expectation()
    {
        int numChest = 0;
        int numCrotch = 0;
        int numThroat = 0;
        //string expectation = partsSteppedOn[Random.Range(0, partsSteppedOn.Count)];
        for(int i = 0; i < partsSteppedOn.Count; i++)
        {
            if(partsSteppedOn[i] == "Throat")
            {
                numThroat += 1;
            }
            else if(partsSteppedOn[i] == "Crotch")
            {
                numCrotch += 1;
            }
            else if(partsSteppedOn[i] == "Chest")
            {
                numChest += 1;
            }
        }
        if(numChest > numCrotch && numChest > numThroat)
        {
            expectation = "Chest";
        }
        else if(numCrotch > numChest && numCrotch > numThroat)
        {
            expectation = "Crotch";
        }
        else if(numThroat > numChest && numThroat > numCrotch)
        {
            expectation = "Throat";
        }
        else
        {
            expectation = "";
        }
        Debug.Log(expectation);
    }

}
