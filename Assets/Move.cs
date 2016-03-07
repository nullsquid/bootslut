using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    public float speed;
    public bool canMove = true;
    private float mousePosX;
    private float mousePosY;
    private Transform thisObjectTransform;
    private Stomp stomp;
	// Use this for initialization
	void Start () {
        thisObjectTransform = gameObject.transform;
        stomp = GetComponent<Stomp>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove == true)
        {
            mousePosY = Input.mousePosition.y;
            mousePosX = Input.mousePosition.x;
            thisObjectTransform.localPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, 0);
            if (stomp.isStomping == false)
            {
                thisObjectTransform.localPosition = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            }

            if (thisObjectTransform.localPosition.y > 3.0f)
            {
                thisObjectTransform.localPosition = new Vector3(thisObjectTransform.localPosition.x, 3.0f, thisObjectTransform.localPosition.z);
            }
            if (thisObjectTransform.localPosition.y < 1.3f)
            {
                thisObjectTransform.localPosition = new Vector3(thisObjectTransform.localPosition.x, 1.3f, thisObjectTransform.localPosition.z);
            }
            

            if (thisObjectTransform.localPosition.x > 2.0f)
            {
                thisObjectTransform.localPosition = new Vector3(2.0f, thisObjectTransform.localPosition.y, thisObjectTransform.localPosition.z);
            }
            else if(thisObjectTransform.localPosition.x < -2.0f)
            {
                thisObjectTransform.localPosition = new Vector3(-2.0f, thisObjectTransform.localPosition.y, thisObjectTransform.localPosition.z);

            }

        }
    }
}
