using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {
    public bool isStomping;
    public float startPos;
    public float endPos;
    public float newYPos;
    public float stompSpeed = 1.0f;
    public int painMultiplier;
    public int numOfStomps;
    public float multiTimer;
    public float multiCurTime;
    public float expectationModifier;
    public float basePleasure;
    public Stats slutStats;
    public ExpectationController expectations;

    void OnEnable()
    {
        EventManager.StartListening("onThroat", SteppedOnThroat);
        EventManager.StartListening("onChest", SteppedOnChest);
        EventManager.StartListening("onCrotch", SteppedOnCrotch);
    }

    void OnDisable()
    {
        EventManager.StopListening("onThroat", SteppedOnThroat);
        EventManager.StopListening("onChest", SteppedOnChest);
        EventManager.StopListening("onCrotch", SteppedOnCrotch);
    }
    void Start()
    {
        numOfStomps = painMultiplier;
        slutStats = GameObject.Find("Slut").GetComponent<Stats>();
        expectations = GameObject.Find("Slut").GetComponent<ExpectationController>();

    }
    void Update()
    {
        PainMultiplier();
        if (Input.GetMouseButtonDown(0))
        {
            isStomping = true;
            newYPos = transform.position.y;
            StopAllCoroutines();
            StartCoroutine(BootStomp(transform, transform.position, new Vector3(transform.position.x, .73f, transform.position.z), 1.0f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            StartCoroutine(BootStomp(transform, transform.position, new Vector3(transform.position.x, newYPos, transform.position.z), .5f));
            isStomping = false;
        }
        stompSpeed = transform.position.y * 1.75f;
    }
	IEnumerator BootStomp(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        
        
        float i = 0.0f;
        float rate = stompSpeed/time;
        while(i <= 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        numOfStomps += 1;
        multiCurTime = 0;
        if (other.name == "Throat")
        {
            SteppedOnThroat();
           
        }
        else if (other.name == "Chest")
        {
            SteppedOnChest();
        }
        else if (other.name == "Crotch")
        {
            SteppedOnCrotch();
        }
    }

    void SteppedOnThroat()
    {
        GameObject.Find("Slut").GetComponent<ExpectationController>().partsSteppedOn.Add("Throat");
        GameObject.Find("Slut").GetComponent<Stats>().pain += InflictPain();
        slutStats.arousal += GivePleasure();
        EventManager.TriggerEvent("expectation");
        

    }

    void SteppedOnCrotch()
    {
        GameObject.Find("Slut").GetComponent<ExpectationController>().partsSteppedOn.Add("Crotch");
        GameObject.Find("Slut").GetComponent<Stats>().pain += InflictPain();
        slutStats.arousal += GivePleasure();
        EventManager.TriggerEvent("expectation");

    }

    void SteppedOnChest()
    {
        GameObject.Find("Slut").GetComponent<ExpectationController>().partsSteppedOn.Add("Chest");
        GameObject.Find("Slut").GetComponent<Stats>().pain += InflictPain();
        slutStats.arousal += GivePleasure();
        EventManager.TriggerEvent("expectation");

    }
    float InflictPain()
    {
        return (stompSpeed / 2f) * (numOfStomps / 2.5f);
    }
    float GivePleasure()
    {
        float totalPleasure = 0;

        //if(expectations.)
        if(expectations.expectation != expectations.partsSteppedOn[0])
        {
            totalPleasure = basePleasure * expectationModifier;
        }
        if(numOfStomps > 5)
        {
            totalPleasure -= totalPleasure / 2;
            slutStats.arousal -= totalPleasure;
        }
        else
        {
            totalPleasure = basePleasure;
        }
        Debug.Log(totalPleasure);
        return totalPleasure;
    }
    void PainMultiplier()
    {
        if(numOfStomps > 2)
        {
            multiCurTime += Time.deltaTime;
            if(multiCurTime > multiTimer)
            {
                multiCurTime = 0;
                numOfStomps = 0;
            }
            /*if(numOfStomps != painMultiplier)
            {
                multiCurTime = 0;
            }*/
        }
    }
    void Exhaust()
    {
        slutStats.exhaustion += 1.0f;
    }

    


    
}
