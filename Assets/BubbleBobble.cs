using UnityEngine;
using System.Collections;

public class BubbleBobble : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(BubbleWiggle());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator BubbleWiggle() {
        while (true) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 15);
            yield return new WaitForSeconds(1.0f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            yield return new WaitForSeconds(1.0f);

        }
    }
}
