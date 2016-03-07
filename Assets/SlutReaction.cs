using UnityEngine;
using System.Collections;

public class SlutReaction : MonoBehaviour {
    public bool isBeingSteppedOn = false;
    public float yellowThreshold;
    public float redThreshold;
    public int numberOfPainEdges = 0;
    public float painMultiplierAmt = 1.5f;
    public float painMultiplier = 0f;
    public Stats slutStats;

    void Start()
    {
        slutStats = GetComponent<Stats>();
        StartCoroutine(PainController());
    }
    //this might have to go in boot
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Throat")
        {
            isBeingSteppedOn = true;
            Debug.Log("Stepped On Throat");
        }
        else if (other.name == "Crotch")
        {
            isBeingSteppedOn = true;
        }
        else if(other.name == "Chest")
        {
            isBeingSteppedOn = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isBeingSteppedOn = false;
    }

    void Arousal()
    {


    }

    void Pain()
    {

    }
    void PainIncrease()
    {

    }
    IEnumerator PainReset()
    {
        //start this coroutine every time pain is inflicted
        float oldPainMultiplier = 0.0f;
        float countToPainReset = 2.5f;
        while(painMultiplier > oldPainMultiplier)
        {
            yield return new WaitForSeconds(countToPainReset);
            painMultiplier = 0.0f;
        }
        
    }

    void EdgeOfPainThreshold()
    {
        
    }

    IEnumerator ArousalController()
    {
        yield return null;
    }
    IEnumerator PainController()
    {
        while (slutStats.pain > 0)
        {
            if (slutStats.pain <= 0)
            {
                slutStats.pain = 0;
            }
            else
            {
                slutStats.pain -= 1;
                yield return new WaitForSeconds(0.5f);
            }

            if(slutStats.pain > yellowThreshold)
            {
                Debug.LogWarning("Yellow");
                if(slutStats.pain > redThreshold)
                {
                    Debug.LogWarning("Red");
                }
            }
            
        }
        yield return null;
    }


}
