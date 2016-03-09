using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {
    public bool isStomping;
    public float startPos;
    public float endPos;
    public float newYPos;
    public float stompSpeed = 1.0f;
    public ExpectationController expectations;
    void Start()
    {
        
    }

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
    void Update()
    {
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
        EventManager.TriggerEvent("expectation");

    }

    void SteppedOnCrotch()
    {
        GameObject.Find("Slut").GetComponent<ExpectationController>().partsSteppedOn.Add("Crotch");
        EventManager.TriggerEvent("expectation");

    }

    void SteppedOnChest()
    {
        GameObject.Find("Slut").GetComponent<ExpectationController>().partsSteppedOn.Add("Chest");
        EventManager.TriggerEvent("expectation");

    }
}
