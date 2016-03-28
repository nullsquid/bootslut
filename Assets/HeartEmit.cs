using UnityEngine;
using System.Collections;

public class HeartEmit : MonoBehaviour {
    public Stats slutStats;
    public GameObject heartPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EmitHearts();
        }
	}

    void EmitHearts()
    {
        GameObject newHeart = Instantiate(heartPrefab, transform.position, transform.rotation) as GameObject;
        newHeart.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, slutStats.arousal * 10));
    }
}
